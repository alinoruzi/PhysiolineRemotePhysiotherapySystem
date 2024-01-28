using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands
{
	public interface IDeletePlanByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
