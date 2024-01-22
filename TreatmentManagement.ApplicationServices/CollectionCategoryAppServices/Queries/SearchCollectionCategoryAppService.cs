using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Queries
{
	public class SearchCollectionCategoryAppService: ISearchCollectionCategoryAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchCollectionCategoryAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<CollectionCategorySearchResultDto>> Run(CollectionCategorySearchInputDto dto, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionCategoryRepository
					.GetAllAsync(cc
						=> cc.Title.Contains(dto.Title), cancellationToken))
				.Select(CollectionCategoryMapper.MapToSearchResult).ToList();
	}
}