using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetExercisesByAdminAppService
	{
		Task<ValueTask<List<ExerciseAdminListItemDto>>> Run(CancellationToken cancellationToken);
	}
}
