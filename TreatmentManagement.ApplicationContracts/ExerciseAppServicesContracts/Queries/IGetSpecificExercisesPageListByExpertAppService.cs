using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetSpecificExercisesPageListByExpertAppService
	{
		Task<List<GetExerciseListItemByExpertDto>> Run(int pageNumber,
			int pageSize, long userId, CancellationToken cancellationToken);
	}
}
