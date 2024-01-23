using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands
{
	public interface IEditCollectionByExpertAppService
	{
		Task<OperationResult> Run(EditCollectionDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
