using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class DeleteExerciseByExpertAppService : IDeleteExerciseByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteExerciseByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);

			if (exercise.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}


			foreach (var item in exercise.Collections)
				item.IsDeleted = true;

			exercise.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(Exercise), id);
			return OperationResult.Success(message);
		}
	}
}
