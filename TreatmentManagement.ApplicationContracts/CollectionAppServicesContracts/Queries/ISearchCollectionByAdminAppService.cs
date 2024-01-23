using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface ISearchCollectionByAdminAppService
	{
		Task<List<SearchCollectionOutputDto>> Run(SearchCollectionOutputDto dto,
			CancellationToken cancellationToken);
	}

}
