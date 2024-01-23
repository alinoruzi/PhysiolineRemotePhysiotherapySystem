using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands
{
	public interface IDeleteCollectionDetailByExpertAppService
	{
		Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken);
	}
}
