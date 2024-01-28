using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetGlobalExercisesPageListByExpertAppService
	{
		Task<List<GetExerciseListItemByExpertDto>> Run(int pageNumber, 
			int pageSize, CancellationToken cancellationToken);
	}
}
