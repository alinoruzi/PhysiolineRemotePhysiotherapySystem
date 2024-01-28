using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries
{
	public interface IGetExerciseCategoriesPageListByAdminAppService
	{
		Task<List<GetExerciseCategoryListItemDto>> Run(int pageNumber, int pageSize,
			CancellationToken cancellationToken);
	}

}
