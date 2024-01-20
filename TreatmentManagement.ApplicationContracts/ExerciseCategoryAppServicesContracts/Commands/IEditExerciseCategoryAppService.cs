using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands
{
	public interface IEditExerciseCategoryAppService
	{
		Task<OperationResult> Run(EditExerciseCategoryDto dto, CancellationToken cancellationToken);
	}
}
