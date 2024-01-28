using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetPlansListByExpertAppService
	{
		Task<List<GetPlanByExpertDto>> Run(long userId, 
			CancellationToken cancellationToken);
	}
}
