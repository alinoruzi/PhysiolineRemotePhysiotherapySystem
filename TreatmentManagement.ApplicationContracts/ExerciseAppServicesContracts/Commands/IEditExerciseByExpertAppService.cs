using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IEditExerciseByExpertAppService
	{
		public Task<OperationResult> Run(EditExerciseDto dto, long userId, CancellationToken cancellationToken);
	}
}
