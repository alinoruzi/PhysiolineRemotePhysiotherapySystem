using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IDeactivateUserByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
