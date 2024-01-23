using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands
{
	public class AddCollectionDetailByAdminAppService : IAddCollectionDetailByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddCollectionDetailByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(AddCollectionDetailDto dto,
			long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c => c.Id == dto.CollectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), dto.CollectionId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			//Check Is the Selected Collection global:
			if (!(await _unitOfWork.CollectionRepository
				    .GetAsync(dto.CollectionId, cancellationToken)).IsGlobal)
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

			//Check Is the Selected Exercise global:
			if (!(await _unitOfWork.ExerciseRepository
				    .GetAsync(dto.ExerciseId, cancellationToken)).IsGlobal)
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
