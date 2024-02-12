using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.Domain.Enums;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries
{
	public interface IGetUsersPageListByAdminAppService
	{
		Task<List<GetUserListItemDto>> Run(UserRole role, int pageNumber, int pageSize, CancellationToken cancellationToken);
	}
}
