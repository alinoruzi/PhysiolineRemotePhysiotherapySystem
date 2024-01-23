using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Commands
{
	public class EditCollectionByAdminAppService : IEditCollectionByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditCollectionByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditCollectionDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c
					    => c.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), dto.Id);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);

			}
			
			if (!await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc => cc.Id == dto.CategoryId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionCategory), dto.CategoryId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(dto.Id,cancellationToken);

			CollectionMapper.Map(collection, dto);
			
			_unitOfWork.CollectionRepository.Update(collection);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyEdited(nameof(collection), collection.Id);
			return OperationResult.Success(message);
		}
	}
}
