using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands
{
	public interface IDeleteCollectionCategoryByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
