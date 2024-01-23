using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class GetCollectionByExpertAppService : IGetCollectionByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<ValueResult<GetCollectionByExpertDto>> Run(long id, long userId,
			CancellationToken cancellationToken)
		{
			ResultMessage message;
			
			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c
					    => c.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), id);
				return ValueResult<GetCollectionByExpertDto>.Failed(message,HttpStatusCode.NotFound);

			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(id, cancellationToken);

			if (collection.CreatorUserId != userId && !collection.IsGlobal)
			{
				message = ResultMessage.DontHavePermission();
				return ValueResult<GetCollectionByExpertDto>.Failed(message,HttpStatusCode.Unauthorized);
			}
				
			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetCollectionByExpertDto>.Success(CollectionMapper.MapToExpertDto(collection), message);
		}
	}
}
