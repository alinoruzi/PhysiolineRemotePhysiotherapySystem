using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands
{
	public interface IAddCollectionDetailByExpertAppService
	{
		Task<OperationResult> Run(AddCollectionDetailDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
