using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class DeleteExerciseCategoryByAdminAppService : IDeleteExerciseCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteExerciseCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec
					    => ec.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository
				.GetAsync(id, cancellationToken);

			if (await _unitOfWork.ExerciseRepository.IsExistAsync(c=>c.CategoryId == id,cancellationToken))
			{
				message = ResultMessage.CategoryCanNotBeDelete();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			exerciseCategory.IsDeleted = true;
			_unitOfWork.ExerciseCategoryRepository.Update(exerciseCategory);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(exerciseCategory), exerciseCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
