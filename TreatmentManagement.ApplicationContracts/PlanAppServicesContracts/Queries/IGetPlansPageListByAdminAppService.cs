using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetPlansPageListByAdminAppService
	{
		Task<List<GetPlanByAdminDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken);
	}
}
