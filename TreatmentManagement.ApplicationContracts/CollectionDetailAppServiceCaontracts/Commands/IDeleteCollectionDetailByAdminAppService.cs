using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands
{
	public interface IDeleteCollectionDetailByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
