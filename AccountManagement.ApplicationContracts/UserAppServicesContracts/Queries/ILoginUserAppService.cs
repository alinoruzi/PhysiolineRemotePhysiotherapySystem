using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries
{
	public interface ILoginUserAppService
	{
		Task<ValueResult<LoginResultDto>> Run(LoginInputDto dto, CancellationToken cancellationToken);
	}
}
