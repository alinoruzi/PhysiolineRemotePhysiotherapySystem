using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class SearchCollectionByExpertAppService : ISearchCollectionByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchCollectionByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<SearchCollectionOutputDto>> Run(SearchCollectionInputDto dto,
			long userId, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionRepository
					.GetAllAsync(c
						=> c.Title.Contains(dto.Title) && (c.IsGlobal || c.CreatorUserId == userId), cancellationToken))
				.Select(CollectionMapper.MapToSearchResult).ToList();
	}
}
