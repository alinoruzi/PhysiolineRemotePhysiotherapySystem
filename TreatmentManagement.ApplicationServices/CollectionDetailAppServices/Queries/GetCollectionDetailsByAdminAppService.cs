using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Queries
{
	public class GetCollectionDetailsByAdminAppService : IGetCollectionDetailsByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionDetailsByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionDetailItemDto>> Run(long collectionId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.CollectionDetailRepository
					.GetAllAsync(cd => cd.CollectionId == collectionId, cancellationToken))
				.Select(CollectionDetailMapper.Map)
				.OrderBy(x => x.Priority).ToList();
		}
	}
}
