using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands
{
	public interface IDeletePlanDetailByExpertAppService
	{
		Task<OperationResult> Run(long id, long userId,
			CancellationToken cancellationToken);
	}
}
