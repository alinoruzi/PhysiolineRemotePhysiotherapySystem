using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IEditCollectionByAdminAppService
	{
		Task<OperationResult> Run(EditCollectionDto dto,
			CancellationToken cancellationToken);
	}
}
