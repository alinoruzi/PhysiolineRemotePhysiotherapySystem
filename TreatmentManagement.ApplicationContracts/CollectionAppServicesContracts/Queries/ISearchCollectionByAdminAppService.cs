using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface ISearchCollectionByAdminAppService
	{
		Task<List<SearchCollectionOutputDto>> Run(SearchCollectionInputDto dto,
			CancellationToken cancellationToken);
	}

}
