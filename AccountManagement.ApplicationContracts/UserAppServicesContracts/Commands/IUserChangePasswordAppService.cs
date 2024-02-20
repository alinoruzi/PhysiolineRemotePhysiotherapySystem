using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IUserChangePasswordAppService
	{
		Task<OperationResult> Run(ChangePasswordDto dto, long userId, CancellationToken cancellationToken);
	}
}
