using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries
{
	public class GetExerciseCategoriesPageListByAdminAppService : IGetExerciseCategoriesPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExerciseCategoriesPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseCategoryListItemDto>> Run(int pageNumber, int pageSize, CancellationToken cancellationToken)
			=> (await _unitOfWork.ExerciseCategoryRepository
					.GetPageAsync(pageNumber, pageSize, cancellationToken))
				.Select(ExerciseCategoryMapper.MapToListItem).ToList();
	}
}
