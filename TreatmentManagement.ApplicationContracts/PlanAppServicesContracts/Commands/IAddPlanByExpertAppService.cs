using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands
{
	public interface IAddPlanByExpertAppService
	{
		Task<OperationResult> Run(AddPlanDto dto, long userId,
			CancellationToken cancellationToken);
	}

}
