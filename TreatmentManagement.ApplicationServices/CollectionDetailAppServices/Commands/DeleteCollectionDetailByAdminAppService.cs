using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class DeleteCollectionDetailByAdminAppService : IDeleteCollectionDetailByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCollectionDetailByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionDetailRepository
				    .IsExistAsync(cd => cd.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionDetail), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionDetail = await _unitOfWork.CollectionDetailRepository.GetAsync(id, cancellationToken);


			collectionDetail.IsDeleted = true;
			
			_unitOfWork.CollectionDetailRepository.Update(collectionDetail);
			
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(collectionDetail), collectionDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
