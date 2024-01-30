using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetGlobalExercisesPageListByExpertAppService : IGetGlobalExercisesPageListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetGlobalExercisesPageListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseListItemByExpertDto>> Run(int pageNumber, int pageSize,
			CancellationToken cancellationToken)
		{
			var exercises = await _unitOfWork.ExerciseRepository
				.GetPageAsync(e => e.IsGlobal, pageNumber, pageSize, cancellationToken);
			return exercises.Select(ExerciseMapper.MapToListItemByExpert).ToList();
		}
	}
}
