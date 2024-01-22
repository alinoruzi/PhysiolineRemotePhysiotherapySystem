using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetExerciseByExpertAppService
	{
		Task<ValueResult<GetExerciseByExpertDto>> Run(long id, CancellationToken cancellationToken);
	}
}
