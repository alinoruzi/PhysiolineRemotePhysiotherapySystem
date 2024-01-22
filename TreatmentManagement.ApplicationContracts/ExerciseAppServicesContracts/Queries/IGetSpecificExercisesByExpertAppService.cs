using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetSpecificExercisesByExpertAppService
	{
		Task<List<GetExerciseListItemByExpertDto>> Run(int pageNumber, 
			int pageSize, long userId, CancellationToken cancellationToken);
	}
}
