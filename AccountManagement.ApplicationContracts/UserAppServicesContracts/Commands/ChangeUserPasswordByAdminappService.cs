using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IChangeUserPasswordByAdminAppService
	{
		Task<OperationResult> Run(ChangeUserPasswordBtAdminDto dto, CancellationToken cancellationToken);
	}
}
