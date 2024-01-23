using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetSpecificCollectionsPageByExpertAppService
	{
		Task<List<GetCollectionListItemByExpertDto>> Run(int pageNumber,
			int pageSize, long userId, CancellationToken cancellationToken);
	}
}
