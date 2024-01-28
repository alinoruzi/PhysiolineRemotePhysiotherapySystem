using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries
{
	public interface IGetCollectionCategoriesPageListByAdminAppService
	{
		Task<List<GetCollectionCategoryListItemDto>> Run(int pageNumber, int pageSize,
			CancellationToken cancellationToken);
	}

}
