using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands
{
	public interface IEditCollectionDetailByExpertAppService
	{
		Task<OperationResult> Run(EditCollectionDetailDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
