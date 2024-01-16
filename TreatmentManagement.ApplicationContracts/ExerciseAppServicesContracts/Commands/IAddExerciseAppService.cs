using Physioline.Framework.Application;
using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IAddExerciseAppService
	{
		Task<OperationResult> Run(AddExerciseDto dto, CancellationToken cancellationToken);
	}
}
