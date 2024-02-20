using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Repositories;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Queries
{
	public class GetSpecializedTitlesPageListByAdminAppService : IGetSpecializedTitlesPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetSpecializedTitlesPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetSpecializedTitleListItemDto>> Run(int pageNumber, int pageSize, CancellationToken cancellationToken)
			=> (await _unitOfWork.SpecializedTitleRepository
					.GetPageAsync(pageNumber, pageSize, cancellationToken))
				.Select(SpecializedTitleMapper.MapToListItem).ToList();
	}
}
