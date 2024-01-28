using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries
{
	public interface IGetAllPlanDetailsByClientAppService
	{
		Task<List<GetPlanDetailDto>> Run(long planId, long userId,
			CancellationToken cancellationToken);
	}
}
