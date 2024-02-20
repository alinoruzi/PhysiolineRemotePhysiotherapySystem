using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands
{
	public interface IDeleteSpecializedTitleByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
