using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries
{
	public interface IGetExerciseCategoryAppService
	{
		Task<ValueResult<GetExerciseCategoryDto>> Run(long id, CancellationToken cancellationToken);
	}
}
