using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class SearchExerciseByExpertAppService : ISearchExerciseByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchExerciseByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<SearchResultExerciseDto>> Run(SearchInputExerciseDto dto, long userId, CancellationToken cancellationToken)
		{
			var exercises = await _unitOfWork.ExerciseRepository
				.GetAllAsync(e
						=> e.Title.Contains(dto.Title) && (e.IsGlobal || e.CreatorUserId == userId),
					cancellationToken);
			return exercises.Select(ExerciseMapper.MapToSearchResult).ToList();

		}
	}
}
