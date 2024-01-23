using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
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
			ResultMessage message;
			if (!await _unitOfWork.CollectionRepository.IsExistAsync(c => c.Id == collectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), collectionId);
				throw new OperationResult(message);
			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(collectionId, cancellationToken);

			if (collection.CreatorUserId == userId)
				return collection.Details.Select(CollectionDetailMapper.Map).ToList();

			message = ResultMessage.DontHavePermission();
			throw new OperationResult(message);
		}
	}
}
