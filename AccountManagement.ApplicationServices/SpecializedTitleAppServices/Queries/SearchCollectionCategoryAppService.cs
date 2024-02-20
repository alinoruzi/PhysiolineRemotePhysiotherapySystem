using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Repositories;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Queries
{
	public class SearchSpecializedTitleAppService : ISearchSpecializedTitleAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SearchSpecializedTitleAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<SpecializedTitleSearchResultDto>> Run(SpecializedTitleSearchInputDto dto, CancellationToken cancellationToken)
		{
			if (dto.Title == null)
				return (await _unitOfWork.SpecializedTitleRepository
						.GetAllAsync(cancellationToken))
					.Select(SpecializedTitleMapper.MapToSearchResult).ToList();
			return (await _unitOfWork.SpecializedTitleRepository
					.GetAllAsync(cc
						=> cc.Title.Contains(dto.Title), cancellationToken))
				.Select(SpecializedTitleMapper.MapToSearchResult).ToList();
		}
	}
}
