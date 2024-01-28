using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands
{
	public interface IDeletePlanByExpertAppService
	{
		Task<OperationResult> Run(long id, long userId,
			CancellationToken cancellationToken);
	}
}
