using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetAllPlansByClientAppService
	{
		Task<List<GetPlanByClientDto>> Run(long userId, CancellationToken cancellationToken);
	}
}
