using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries
{
	public interface IGetPlanDetailsByAdminAppService
	{
		Task<List<GetPlanDetailDto>> Run(long planId,
			CancellationToken cancellationToken);
	}
}
