using Physioline.Framework.Application.CustomValidations;
using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetExerciseByAdminAppService
	{
		Task<ValueResult<GetExerciseByAdminDto>> Run(long id, CancellationToken cancellationToken);
	}
}
