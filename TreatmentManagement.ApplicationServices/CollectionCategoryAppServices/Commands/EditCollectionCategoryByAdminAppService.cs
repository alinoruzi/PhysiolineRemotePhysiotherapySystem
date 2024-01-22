using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Commands
{
	public class EditCollectionCategoryByAdminAppService : IEditCollectionCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditCollectionCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(EditCollectionCategoryDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc 
					    => cc.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionCategory), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionCategory = await _unitOfWork.CollectionCategoryRepository
				.GetAsync(dto.Id, cancellationToken);

			if (collectionCategory.Title != dto.Title)
			{
				if (await _unitOfWork.CollectionCategoryRepository
					    .IsExistAsync(cc
						    => cc.Title == dto.Title, cancellationToken))
				{
					message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(CollectionCategory), nameof(CollectionCategory.Title));
					return OperationResult.Failed(message, HttpStatusCode.BadRequest);
				}
			}

			CollectionCategoryMapper.MapForEdit(collectionCategory, dto);

			_unitOfWork.CollectionCategoryRepository.Update(collectionCategory);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(CollectionCategory), collectionCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
