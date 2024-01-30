using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetSpecificExercisesPageListByExpertAppService : IGetSpecificExercisesPageListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetSpecificExercisesPageListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseListItemByExpertDto>> Run(int pageNumber, int pageSize, long userId, CancellationToken cancellationToken)
		{
			var exercises = await _unitOfWork.ExerciseRepository
				.GetPageAsync(e => e.CreatorUserId == userId, pageNumber,
					pageSize, cancellationToken);
			return exercises.Select(ExerciseMapper.MapToListItemByExpert).ToList();
		}
	}
}
