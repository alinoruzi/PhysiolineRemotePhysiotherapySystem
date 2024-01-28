using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands
{
	public interface IEditPlanDetailByExpertAppService
	{
		Task<OperationResult> Run(EditPlanDetailDto dto, long userId,
			CancellationToken cancellationToken);
	}

}
