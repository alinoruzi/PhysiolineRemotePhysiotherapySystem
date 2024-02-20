using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands
{
	public interface IAddSpecializedTitleByAdminAppService
	{
		Task<OperationResult> Run(AddSpecializedTitleDto dto,
			long userId, CancellationToken cancellationToken);
	}

}
