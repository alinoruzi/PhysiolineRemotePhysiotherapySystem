using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IDeleteExerciseByAdminAppService
	{
		Task<OperationResult> Run(long id, CancellationToken cancellationToken);
	}
}
