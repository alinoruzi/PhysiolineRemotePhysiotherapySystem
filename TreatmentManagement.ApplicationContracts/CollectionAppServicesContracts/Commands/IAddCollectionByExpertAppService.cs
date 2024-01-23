using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IAddCollectionByExpertAppService
	{
		Task<OperationResult> Run(AddCollectionDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
