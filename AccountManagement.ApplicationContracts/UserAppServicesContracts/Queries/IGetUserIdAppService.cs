using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries
{
	public interface IGetUserIdAppService
	{
		Task<ValueResult<long>> Run(EmailDto dto, CancellationToken cancellationToken);
	}
}
