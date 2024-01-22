using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries
{
	public interface IGetCollectionCategoryPageListByAdminAppService
	{
		Task<List<GetCollectionCategoryListItemDto>> Run(int pageNumber, int pageSize,
			CancellationToken cancellationToken);
	}

}
