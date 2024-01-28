using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands
{
	public interface IDeleteExerciseCategoryByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
