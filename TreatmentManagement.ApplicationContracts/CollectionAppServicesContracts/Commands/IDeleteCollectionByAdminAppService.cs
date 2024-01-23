using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IDeleteCollectionByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
