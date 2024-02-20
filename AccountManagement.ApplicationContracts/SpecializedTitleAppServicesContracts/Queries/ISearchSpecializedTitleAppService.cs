using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries
{
	public interface ISearchSpecializedTitleAppService
	{
		Task<List<SpecializedTitleSearchResultDto>> Run(
			SpecializedTitleSearchInputDto dto,
			CancellationToken cancellationToken);
	}
}
