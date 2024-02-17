using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Commands
{
	public class DeleteCollectionCategoryByAdminAppService : IDeleteCollectionCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCollectionCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc
					    => cc.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionCategory), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionCategory = await _unitOfWork.CollectionCategoryRepository
				.GetAsync(id, cancellationToken);

			if (await _unitOfWork.CollectionRepository.IsExistAsync(c=>c.CategoryId == id,cancellationToken))
			{
				message = ResultMessage.CategoryCanNotBeDelete();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			collectionCategory.IsDeleted = true;
			_unitOfWork.CollectionCategoryRepository.Update(collectionCategory);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(CollectionCategory), collectionCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
