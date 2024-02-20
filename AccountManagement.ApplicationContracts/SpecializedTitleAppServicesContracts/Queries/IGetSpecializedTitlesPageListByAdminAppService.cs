using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries
{
	public interface IGetSpecializedTitlesPageListByAdminAppService
	{
		Task<List<GetSpecializedTitleListItemDto>> Run(int pageNumber, int pageSize,
			CancellationToken cancellationToken);
	}

}
