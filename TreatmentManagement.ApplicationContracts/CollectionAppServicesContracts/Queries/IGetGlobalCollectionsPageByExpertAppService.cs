using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetGlobalCollectionsPageByExpertAppService
	{
		Task<List<GetCollectionListItemByExpertDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken);
	}
}
