using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries
{
	public class GetAllExerciseCategoriesAppService : IGetAllExerciseCategoriesAppService
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public GetAllExerciseCategoriesAppService(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}

		public async Task<List<ExerciseCategoryListItemDto>> Run(CancellationToken cancellationToken)
		{
			var exerciseCategories = await _exerciseCategoryService.GetAll(cancellationToken);
			return exerciseCategories.Select(ExerciseCategoryMapper.MapToListItem).ToList();
		}
	}
}
