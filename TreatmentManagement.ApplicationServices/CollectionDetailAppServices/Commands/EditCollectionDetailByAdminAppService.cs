using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class EditCollectionDetailByAdminAppService : IEditCollectionDetailByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditCollectionDetailByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditCollectionDetailDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionDetailRepository
				    .IsExistAsync(cd => cd.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionDetail), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionDetail = await _unitOfWork.CollectionDetailRepository.GetAsync(dto.Id, cancellationToken);
			if (!collectionDetail.Collection.IsGlobal)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}

			var collection = await _unitOfWork.CollectionDetailRepository.GetAsync(dto.Id, cancellationToken);
			CollectionDetailMapper.Map(collectionDetail, dto);

			_unitOfWork.CollectionDetailRepository.Update(collection);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(collectionDetail), collection.Id);
			return OperationResult.Success(message);
		}
	}
}
