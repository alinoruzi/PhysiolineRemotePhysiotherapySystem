using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands
{
	public interface IEditExerciseCategoryByAdminAppService
	{
		Task<OperationResult> Run(EditExerciseCategoryDto dto,
			CancellationToken cancellationToken);
	}
}
