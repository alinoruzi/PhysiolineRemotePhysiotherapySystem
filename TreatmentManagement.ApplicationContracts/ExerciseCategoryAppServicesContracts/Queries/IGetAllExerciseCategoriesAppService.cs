using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries
{
	public interface IGetAllExerciseCategoriesAppService
	{
		Task<List<ExerciseCategoryListItemDto>> Run(CancellationToken cancellationToken);
	}
}
