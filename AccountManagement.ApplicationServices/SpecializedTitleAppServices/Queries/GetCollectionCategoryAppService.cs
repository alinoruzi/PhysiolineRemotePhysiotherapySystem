using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Queries
{
	public class GetSpecializedTitleAppService : IGetSpecializedTitleAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetSpecializedTitleAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetSpecializedTitleDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.SpecializedTitleRepository
				    .IsExistAsync(cc
					    => cc.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(SpecializedTitle), id);
				return ValueResult<GetSpecializedTitleDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var specializedTitle = await _unitOfWork
				.SpecializedTitleRepository.GetAsync(id, cancellationToken);

			message = ResultMessage.SuccessfullyGetData();

			return ValueResult<GetSpecializedTitleDto>
				.Success(SpecializedTitleMapper.Map(specializedTitle), message);
		}
	}
}
