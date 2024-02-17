using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Commands
{
	public class DeleteCollectionByExpertAppService : IDeleteCollectionByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCollectionByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c
					    => c.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);

			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(id, cancellationToken);
			
			if (collection.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}
			
			var collectionDetails = await _unitOfWork.CollectionDetailRepository
				.GetAllAsync(cd => cd.CollectionId == id,cancellationToken);
			
			var plans = await _unitOfWork.PlanDetailRepository
				.GetAllAsync(pd => pd.CollectionId == id,cancellationToken);
			
			foreach (var collectionDetail in collectionDetails)
				collectionDetail.IsDeleted = true;

			foreach (var planDetail in plans)
				planDetail.IsDeleted = true;

			collection.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(collection), collection.Id);
			return OperationResult.Success(message);
		}
	}
}
