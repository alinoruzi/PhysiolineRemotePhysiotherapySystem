using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class AddCollectionDetailByExpertAppService : IAddCollectionDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddCollectionDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddCollectionDetailDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c => c.Id == dto.CollectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), dto.CollectionId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			//Check Permission to selected Collection :
			var collection = await _unitOfWork.CollectionRepository.GetAsync(dto.CollectionId, cancellationToken);
			if (collection.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}
			
			
			if (!await _unitOfWork.ExerciseRepository
				    .IsExistAsync(c => c.Id == dto.ExerciseId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), dto.ExerciseId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}
			
			//Check Permission to selected Exercise:
			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(dto.ExerciseId, cancellationToken);
			if (!(exercise.IsGlobal || exercise.CreatorUserId == userId))
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}

			var lastPriority = (await _unitOfWork
					.CollectionDetailRepository.GetAllAsync(cd
						=> cd.CollectionId == dto.CollectionId, cancellationToken))
				.Max(x => x.Priority);

			var collectionDetail = CollectionDetailMapper.Map(dto, userId);

			collectionDetail.Priority = lastPriority + 1;

			await _unitOfWork.CollectionDetailRepository.CreateAsync(collectionDetail, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyAdded(nameof(collectionDetail),collectionDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
