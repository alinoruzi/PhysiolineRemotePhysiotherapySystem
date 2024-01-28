using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class SearchCollectionByAdminAppService : ISearchCollectionByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchCollectionByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<SearchCollectionOutputDto>> Run(SearchCollectionInputDto dto, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionRepository
					.GetAllAsync(c => c.Title.Contains(dto.Title), cancellationToken))
				.Select(CollectionMapper.MapToSearchResult).ToList();
	}
}
