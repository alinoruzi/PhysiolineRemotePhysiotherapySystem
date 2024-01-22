using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Queries
{
	public class GetCollectionCategoryAppService : IGetCollectionCategoryAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionCategoryAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<ValueResult<GetCollectionCategoryDto>> Run(long id, CancellationToken cancellationToken)
		{ 
			ResultMessage message;
			if (!await _unitOfWork.CollectionCategoryRepository
				    .IsExistAsync(cc 
					    => cc.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(CollectionCategory), id);
				return ValueResult<GetCollectionCategoryDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var collectionCategory = await _unitOfWork
				.CollectionCategoryRepository.GetAsync(id, cancellationToken);

			message = ResultMessage.SuccessfullyGetData();
			
			return ValueResult<GetCollectionCategoryDto>
				.Success(CollectionCategoryMapper.Map(collectionCategory),message);
		}
	}
}
