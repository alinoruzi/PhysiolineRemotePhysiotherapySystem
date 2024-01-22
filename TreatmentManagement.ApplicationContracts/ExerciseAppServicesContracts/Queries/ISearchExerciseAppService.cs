using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface ISearchExerciseAppService
	{
		Task<List<SearchResultExerciseDto>> Run(SearchInputExerciseDto dto,
			CancellationToken cancellationToken);
	}
}
