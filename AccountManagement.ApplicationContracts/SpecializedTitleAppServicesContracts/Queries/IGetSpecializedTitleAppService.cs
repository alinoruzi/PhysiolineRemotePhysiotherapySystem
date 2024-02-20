using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries
{
	public interface IGetSpecializedTitleAppService
	{
		Task<ValueResult<GetSpecializedTitleDto>> Run(long id,
			CancellationToken cancellationToken);
	}
}
