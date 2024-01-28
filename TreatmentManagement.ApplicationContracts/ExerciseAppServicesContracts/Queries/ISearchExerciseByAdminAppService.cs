using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface ISearchExerciseByAdminAppService
	{
		Task<List<SearchResultExerciseDto>> Run(SearchInputExerciseDto dto,
			CancellationToken cancellationToken);
	}

}
