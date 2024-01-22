using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IAddExerciseByExpertAppService
	{
		Task<OperationResult> Run(AddExerciseDto dto, long userId, CancellationToken cancellationToken);
	}
	
}
