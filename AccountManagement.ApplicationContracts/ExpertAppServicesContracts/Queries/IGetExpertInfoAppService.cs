using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using Physioline.Framework.Application.ResultModels;

namespace AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Queries
{
	public interface IGetExpertInfoAppService
	{
		public Task<ValueResult<ExpertInfoDto>> Run(long userId, CancellationToken cancellationToken);
	}
}
