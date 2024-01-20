using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class AddExerciseCategoryAppService : IAddExerciseCategoryAppService
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public AddExerciseCategoryAppService(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}
		
		public async Task<OperationResult> Run(AddExerciseCategoryDto dto, CancellationToken cancellationToken)
		{
			if (await _exerciseCategoryService.IsExistByTitle(dto.Title, cancellationToken))
			{
				var message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(ExerciseCategory),nameof(ExerciseCategory.Title));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			var exerciseCategory = ExerciseCategoryMapper.Map(dto);

			await _exerciseCategoryService.Add(exerciseCategory, cancellationToken);

			return OperationResult.Success();
		}
	}
}
