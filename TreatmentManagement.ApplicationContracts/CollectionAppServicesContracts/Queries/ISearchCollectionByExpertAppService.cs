using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface ISearchCollectionByExpertAppService
	{
		Task<List<SearchCollectionOutputDto>> Run(SearchCollectionInputDto dto,
			long userId, CancellationToken cancellationToken);
	}
}
