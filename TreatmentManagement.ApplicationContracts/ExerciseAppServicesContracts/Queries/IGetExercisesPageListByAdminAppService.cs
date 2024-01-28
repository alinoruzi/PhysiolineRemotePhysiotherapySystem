using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries
{
	public interface IGetExercisesPageListByAdminAppService
	{
		Task<List<GetExerciseListItemByAdminDto>> Run(int pageNumber, 
			int pageSize,CancellationToken cancellationToken);
	}
}
