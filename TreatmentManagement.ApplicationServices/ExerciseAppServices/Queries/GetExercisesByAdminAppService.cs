using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExercisesByAdminAppService : IGetExercisesByAdminAppService
	{
		private readonly IExerciseService _exerciseService;
		public GetExercisesByAdminAppService(IExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}
		
		public async Task<ValueTask<List<ExerciseAdminListItemDto>>> Run(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
