using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries
{
	public interface IGetPlanDetailsByExpertAppService
	{
		Task<List<GetPlanDetailDto>> Run(long planId, long userId,
			CancellationToken cancellationToken);
	}

}
