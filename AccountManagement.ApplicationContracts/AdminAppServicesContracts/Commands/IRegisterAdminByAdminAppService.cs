using AccountManagement.ApplicationContracts.AdminAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands
{
	public interface IRegisterAdminByAdminAppService
	{
		Task<OperationResult> Run(RegisterAdminDto dto, long userId, CancellationToken cancellationToken);
	}
}
