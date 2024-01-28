using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IConfirmUserByAdmin
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
