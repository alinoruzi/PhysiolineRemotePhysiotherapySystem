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

			Exercise exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);
			
			
			foreach (var item in exercise.Collections)
			{
				item.IsDeleted = true;
			}

			exercise.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(Exercise), id);
			return OperationResult.Success(message);
		}
	}
}
