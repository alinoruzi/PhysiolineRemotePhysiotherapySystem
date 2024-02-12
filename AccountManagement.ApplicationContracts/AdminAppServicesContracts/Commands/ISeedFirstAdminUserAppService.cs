using AccountManagement.ApplicationContracts.AdminAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands
{
	public interface ISeedFirstAdminUserAppService
	{
		Task<OperationResult> Run(CancellationToken cancellationToken);
	}
}
