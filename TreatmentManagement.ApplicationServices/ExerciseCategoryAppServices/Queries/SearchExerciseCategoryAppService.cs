using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries
{
	public class SearchExerciseCategoryAppService : ISearchExerciseCategoryAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchExerciseCategoryAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<ExerciseCategorySearchResultDto>> Run(ExerciseCategorySearchInputDto dto,
			CancellationToken cancellationToken)
		{
			if (dto.Title == null)
				return (await _unitOfWork.ExerciseCategoryRepository
						.GetAllAsync(cancellationToken))
					.Select(ExerciseCategoryMapper.MapToSearchResult).ToList();

			return (await _unitOfWork.ExerciseCategoryRepository
					.GetAllAsync(ec
						=> ec.Title.Contains(dto.Title), cancellationToken))
				.Select(ExerciseCategoryMapper.MapToSearchResult).ToList();
		}
	}
}
