using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Commands
{
	public class AddCollectionByExpertAppService : IAddCollectionByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddCollectionByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddCollectionDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc => cc.Id == dto.CategoryId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionCategory), dto.CategoryId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collection = CollectionMapper.Map(dto, userId);
			collection.IsGlobal = false;

			await _unitOfWork.CollectionRepository.CreateAsync(collection, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(collection), collection.Id);
			return OperationResult.Success(message);
		}
	}
}
