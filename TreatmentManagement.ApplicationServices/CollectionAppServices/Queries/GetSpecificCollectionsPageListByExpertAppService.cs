using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class GetSpecificCollectionsPageListByExpertAppService : IGetSpecificCollectionsPageListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetSpecificCollectionsPageListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionListItemByExpertDto>> Run(int pageNumber,
			int pageSize, long userId, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionRepository
					.GetPageAsync(c => c.CreatorUserId == userId, pageNumber, pageSize, cancellationToken))
				.Select(CollectionMapper.MapToExpertItem).ToList();
	}
}
