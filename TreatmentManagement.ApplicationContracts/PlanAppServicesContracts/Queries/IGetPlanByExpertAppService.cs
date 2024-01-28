using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetPlanByExpertAppService
	{
		Task<ValueResult<GetPlanByExpertDto>> Run(long id, long userId,
			CancellationToken cancellationToken);
	}

}
