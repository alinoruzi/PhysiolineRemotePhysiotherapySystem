using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class DeleteExerciseByAdminAppService : IDeleteExerciseByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteExerciseByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);

			var collectionDetails = await _unitOfWork.CollectionDetailRepository
				.GetAllAsync(cd => cd.ExerciseId == exercise.Id,cancellationToken);
			
			foreach (var item in collectionDetails)
				item.IsDeleted = true;

			exercise.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(Exercise), id);
			return OperationResult.Success(message);
		}
	}
}
