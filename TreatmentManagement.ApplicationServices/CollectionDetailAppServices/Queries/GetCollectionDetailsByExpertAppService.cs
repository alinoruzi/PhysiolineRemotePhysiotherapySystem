using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Queries
{
	public class GetCollectionDetailsByExpertAppService : IGetCollectionDetailsByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionDetailsByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionDetailItemDto>> Run(long collectionId, long userId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.CollectionDetailRepository
					.GetAllAsync(cd => cd.Collection.CreatorUserId == userId && cd.CollectionId == collectionId, cancellationToken))
				.Select(CollectionDetailMapper.Map)
				.OrderBy(x => x.Priority).ToList();
		}
	}
}
