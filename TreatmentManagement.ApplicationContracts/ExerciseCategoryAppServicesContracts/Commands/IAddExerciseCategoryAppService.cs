using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands
{
	public interface IAddExerciseCategoryAppService
	{
		Task<OperationResult> Run(AddExerciseCategoryDto dto, CancellationToken cancellationToken);
	}
}
