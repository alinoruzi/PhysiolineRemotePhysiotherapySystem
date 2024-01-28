using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries
{
	public interface ISearchExerciseCategoryAppService
	{
		Task<List<ExerciseCategorySearchResultDto>> Run(
			ExerciseCategorySearchInputDto dto,
			CancellationToken cancellationToken);
	}
}
