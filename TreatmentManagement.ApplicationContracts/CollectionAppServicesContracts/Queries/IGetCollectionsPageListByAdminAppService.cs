using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetCollectionsPageListByAdminAppService
	{
		Task<List<GetCollectionListItemByAdminDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken);
	}
}
