using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries
{
	public interface IGetUserInfoAppService
	{
		Task<ValueResult<UserInfoDto>> Run(long id, CancellationToken cancellationToken);
	}
}
