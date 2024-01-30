using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class GetCollectionByAdminAppService : IGetCollectionByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetCollectionByAdminDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.CollectionRepository
				    .IsExistAsync(c
					    => c.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection), id);
				return ValueResult<GetCollectionByAdminDto>.Failed(message, HttpStatusCode.NotFound);

			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(id, cancellationToken);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetCollectionByAdminDto>.Success(CollectionMapper.MapToAdminDto(collection), message);
		}
	}
}
