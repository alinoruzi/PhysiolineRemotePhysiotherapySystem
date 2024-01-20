using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class EditExerciseCategoryAppService : IEditExerciseCategoryAppService
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public EditExerciseCategoryAppService(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}

		public async Task<OperationResult> Run(EditExerciseCategoryDto dto, CancellationToken cancellationToken)
		{
			if (!await _exerciseCategoryService.IsExistById(dto.Id, cancellationToken))
			{
				var message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.Id);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			if (await _exerciseCategoryService.IsExistByTitle(dto.Title, cancellationToken))
			{
				var message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(ExerciseCategory),nameof(ExerciseCategory.Title));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var exerciseCategory = await _exerciseCategoryService.GetById(dto.Id, cancellationToken);

			ExerciseCategoryMapper.Map(exerciseCategory,dto);

			await _exerciseCategoryService.CommitChanges(cancellationToken);

			return OperationResult.Success();
		}
	}
}
