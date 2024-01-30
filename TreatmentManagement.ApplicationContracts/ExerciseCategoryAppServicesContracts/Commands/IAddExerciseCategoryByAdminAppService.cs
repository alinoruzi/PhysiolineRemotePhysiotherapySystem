using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands
{
	public interface IAddExerciseCategoryByAdminAppService
	{
		Task<OperationResult> Run(AddExerciseCategoryDto dto,
			long userId, CancellationToken cancellationToken);
	}

}
