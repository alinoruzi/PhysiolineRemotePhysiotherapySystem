using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands
{
	public interface IEditExerciseByAdminAppService
	{
		public Task<OperationResult> Run(EditExerciseDto dto, CancellationToken cancellationToken);
	}

}
