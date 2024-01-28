using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands
{
	public interface IAddPlanDetailByExpertAppService
	{
		Task<OperationResult> Run(AddPlanDetailDto dto, long userId,
			CancellationToken cancellationToken);
	}

}
