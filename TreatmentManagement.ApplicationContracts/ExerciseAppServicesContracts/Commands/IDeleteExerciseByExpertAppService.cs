using Physioline.Framework.Application.ResultModels;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IDeleteExerciseByExpertAppService
	{
		Task<OperationResult> Run(long id, long userid, CancellationToken cancellationToken);
	}
}
