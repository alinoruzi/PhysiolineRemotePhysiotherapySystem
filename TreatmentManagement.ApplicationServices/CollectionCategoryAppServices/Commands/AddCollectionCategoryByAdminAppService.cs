using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Commands
{
	public class AddCollectionCategoryByAdminAppService : IAddCollectionCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddCollectionCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(AddCollectionCategoryDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc
					    => cc.Title == dto.Title, cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(CollectionCategory), nameof(CollectionCategory.Title));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var collectionCategory = CollectionCategoryMapper.Map(dto, userId);
			await _unitOfWork.CollectionCategoryRepository.CreateAsync(collectionCategory, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(CollectionCategory), collectionCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
