using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands
{
	public interface IEditCollectionDetailByAdminAppService
	{
		Task<OperationResult> Run(EditCollectionDetailDto dto, CancellationToken cancellationToken);
	}
}
