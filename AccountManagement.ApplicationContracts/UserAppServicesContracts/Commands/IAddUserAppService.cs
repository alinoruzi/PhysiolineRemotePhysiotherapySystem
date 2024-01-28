using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.Domain.Enums;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands
{
	public interface IAddUserAppService
	{
		Task<OperationResult> Run(AddUserDto dto,UserRole role, long userId,
			CancellationToken cancellationToken);
	}
}
