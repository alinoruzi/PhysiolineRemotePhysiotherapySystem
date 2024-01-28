using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface ISearchExerciseByExpertAppService
	{
		Task<List<SearchResultExerciseDto>> Run(SearchInputExerciseDto dto,
			long userId, CancellationToken cancellationToken);
	}
}
