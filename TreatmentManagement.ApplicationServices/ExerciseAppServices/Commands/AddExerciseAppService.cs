using Physioline.Framework.Application;
using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class AddExerciseAppService : IAddExerciseAppService
	{
		private readonly IExerciseService _exerciseService;
		private readonly IExerciseCategoryService _exerciseCategoryService;

		public AddExerciseAppService(IExerciseService exerciseService, IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseService = exerciseService;
			_exerciseCategoryService = exerciseCategoryService;
		}
		
		public async Task<OperationResult> Run(AddExerciseDto dto, CancellationToken cancellationToken)
		{
			var exercise = ExerciseMapper.Map(dto);
			exercise.IsGlobal = true;
			
			exercise.GuideReferences = dto.GuideReferences
				.Select(ExerciseMapper.Map).ToList();


			if (!await _exerciseCategoryService.IsExistById(dto.CategoryId, cancellationToken))
			{
				var message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.CategoryId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			await _exerciseService.Add(exercise,cancellationToken);
			
			return OperationResult.Success();
		}
		
	}
}
