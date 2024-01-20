using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class DeleteExerciseCategoryAppService : IDeleteExerciseCategoryAppService
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public DeleteExerciseCategoryAppService(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}
		
		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			if (!await _exerciseCategoryService.IsExistById(id, cancellationToken))
			{
				var message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), id);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var exerciseCategory = await _exerciseCategoryService.GetById(id, cancellationToken);
			exerciseCategory.IsDeleted = true;
			await _exerciseCategoryService.CommitChanges(cancellationToken);

			return OperationResult.Success();
		}
	}
}
