using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries
{
	public class GetExerciseCategoryAppService : IGetExerciseCategoryAppService
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public GetExerciseCategoryAppService(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}

		public async Task<ValueResult<GetExerciseCategoryDto>> Run(long id, CancellationToken cancellationToken)
		{ 
			if (!await _exerciseCategoryService.IsExistById(id, cancellationToken))
			{
				var message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), id);
				return ValueResult<GetExerciseCategoryDto>.Failed(message,HttpStatusCode.NotFound);
			}

			var exerciseCategory = await _exerciseCategoryService.GetById(id, cancellationToken);

			return ExerciseCategoryMapper.Map(exerciseCategory);
		}
	}
}
