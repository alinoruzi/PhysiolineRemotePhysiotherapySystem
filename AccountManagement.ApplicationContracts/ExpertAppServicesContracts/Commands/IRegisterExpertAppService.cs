using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands
{
	public interface IRegisterExpertAppService
	{
		Task<OperationResult> Run(RegisterExpertDto dto, CancellationToken cancellationToken);
	}
}
