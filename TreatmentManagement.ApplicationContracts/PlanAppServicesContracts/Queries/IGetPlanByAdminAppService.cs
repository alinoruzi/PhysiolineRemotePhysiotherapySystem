using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetPlanByAdminAppService
	{
		Task<ValueResult<GetPlanByAdminDto>> Run(long id,
			CancellationToken cancellationToken);
	}
}
