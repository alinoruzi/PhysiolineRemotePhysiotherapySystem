using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExercisesPageListByAdminAppService : IGetExercisesPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExercisesPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseListItemByAdminDto>> Run(int pageNumber, int pageSize, CancellationToken cancellationToken)
		{
			var exercises = await _unitOfWork.ExerciseRepository.GetPageAsync(pageNumber, pageSize, cancellationToken);
			return exercises.Select(ExerciseMapper.MapToListItemByAdmin).ToList();
		}
	}
}
