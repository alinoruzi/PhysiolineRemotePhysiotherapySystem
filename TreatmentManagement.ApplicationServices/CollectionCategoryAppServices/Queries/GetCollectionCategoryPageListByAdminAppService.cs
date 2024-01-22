using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Queries
{
	public class GetCollectionCategoryPageListByAdminAppService : IGetCollectionCategoryPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionCategoryPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<List<GetCollectionCategoryListItemDto>> Run(int pageNumber, int pageSize, CancellationToken cancellationToken)
		=> (await _unitOfWork.CollectionCategoryRepository
				.GetPageAsync(pageNumber, pageSize, cancellationToken))
			.Select(CollectionCategoryMapper.MapToListItem).ToList();
	}
}
