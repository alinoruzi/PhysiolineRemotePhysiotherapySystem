using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands
{
	public interface IEditSpecializedTitleByAdminAppService
	{
		Task<OperationResult> Run(EditSpecializedTitleDto dto,
			CancellationToken cancellationToken);
	}
}
