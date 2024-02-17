using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class DeleteCollectionDetailByExpertAppService : IDeleteCollectionDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCollectionDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionDetailRepository
				    .IsExistAsync(cd => cd.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionDetail), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionDetail = await _unitOfWork.CollectionDetailRepository.GetAsync(id, cancellationToken);
			var collection = await _unitOfWork.CollectionRepository.GetAsync(collectionDetail.CollectionId, cancellationToken);
			
			if (collection.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			collectionDetail.IsDeleted = true;
			_unitOfWork.CollectionDetailRepository.Update(collectionDetail);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(collectionDetail), collectionDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
