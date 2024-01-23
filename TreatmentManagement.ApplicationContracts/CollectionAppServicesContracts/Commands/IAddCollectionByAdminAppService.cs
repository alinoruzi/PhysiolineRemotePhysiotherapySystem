using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IAddCollectionByAdminAppService
	{
		Task<OperationResult> Run(AddCollectionDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
