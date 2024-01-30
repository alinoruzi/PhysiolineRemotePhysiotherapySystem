using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Queries
{
	public class GetCollectionDetailsByClientAppService : IGetCollectionDetailsByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionDetailsByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionDetailItemDto>> Run(long collectionId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			return (await _unitOfWork.CollectionDetailRepository
					.GetAllAsync(cd => cd.CollectionId == collectionId, cancellationToken))
				.Select(CollectionDetailMapper.Map)
				.OrderBy(x => x.Priority).ToList();
		}
	}
}
