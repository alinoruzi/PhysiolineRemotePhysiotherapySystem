using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands
{
	public interface IRegisterClientAppService
	{
		Task<OperationResult> Run(RegisterClientDto dto, CancellationToken cancellationToken);
	}
}
