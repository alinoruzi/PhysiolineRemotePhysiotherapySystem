using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands
{
	public interface IEditPlanByExpertAppService
	{
		Task<OperationResult> Run(EditPlanDto dto, long userId,
			CancellationToken cancellationToken);
	}
}
