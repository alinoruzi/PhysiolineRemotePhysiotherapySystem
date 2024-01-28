using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetGlobalCollectionsPageListByExpertAppService
	{
		Task<List<GetCollectionListItemByExpertDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken);
	}
}
