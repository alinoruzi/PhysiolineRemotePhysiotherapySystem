using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class SearchExerciseByAdminAppService : ISearchExerciseByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchExerciseByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<SearchResultExerciseDto>> Run(SearchInputExerciseDto dto, CancellationToken cancellationToken)
		{
			var exercises = await _unitOfWork.ExerciseRepository
				.GetAllAsync(e => e.Title.Contains(dto.Title),
					cancellationToken);
			return exercises.Select(ExerciseMapper.MapToSearchResult).ToList();
		}
	}
}
