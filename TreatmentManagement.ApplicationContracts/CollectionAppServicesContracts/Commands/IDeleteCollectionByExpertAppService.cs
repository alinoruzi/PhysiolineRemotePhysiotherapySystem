using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IDeleteCollectionByExpertAppService
	{
		Task<OperationResult> Run(long id, long userId,
			CancellationToken cancellationToken);
	}
}
