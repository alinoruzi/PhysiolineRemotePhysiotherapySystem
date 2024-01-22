using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries
{
	public interface ISearchCollectionCategoryAppService
	{
		Task<List<CollectionCategorySearchResultDto>> Run(
			CollectionCategorySearchInputDto dto,
			CancellationToken cancellationToken);
	}
}
