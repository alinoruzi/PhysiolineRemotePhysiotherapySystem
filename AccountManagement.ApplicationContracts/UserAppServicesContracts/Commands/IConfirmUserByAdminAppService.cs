using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IConfirmUserByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
