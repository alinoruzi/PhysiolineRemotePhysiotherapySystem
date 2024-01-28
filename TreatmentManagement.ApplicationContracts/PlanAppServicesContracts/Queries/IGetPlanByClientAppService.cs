using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries
{
	public interface IGetPlanByClientAppService
	{
		Task<ValueResult<GetPlanByClientDto>> Run(long id, long userId,
			CancellationToken cancellationToken);
	}
}
