using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
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
			ResultMessage message;
			if (!await _unitOfWork.CollectionRepository.IsExistAsync(c => c.Id == collectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), collectionId);
				throw new OperationResult(message);
			}

			return (await _unitOfWork.CollectionDetailRepository
					.GetAllAsync(cd => cd.CollectionId == collectionId,cancellationToken))
				.Select(CollectionDetailMapper.Map).ToList();
		}
	}
}
