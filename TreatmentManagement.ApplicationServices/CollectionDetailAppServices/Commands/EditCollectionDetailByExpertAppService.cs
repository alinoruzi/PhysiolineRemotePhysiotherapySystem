using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class EditCollectionDetailByExpertAppService : IEditCollectionDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditCollectionDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditCollectionDetailDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionDetailRepository
				    .IsExistAsync(cd => cd.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionDetail), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionDetail = await _unitOfWork.CollectionDetailRepository.GetAsync(dto.Id, cancellationToken);
			var collection = await _unitOfWork.CollectionRepository.GetAsync(collectionDetail.CollectionId, cancellationToken);

			
			if (collection.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			CollectionDetailMapper.Map(collectionDetail, dto);

			_unitOfWork.CollectionDetailRepository.Update(collectionDetail);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(collectionDetail), collectionDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
