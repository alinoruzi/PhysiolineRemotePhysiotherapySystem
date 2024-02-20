using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.ExpertAppServices.Queries
{
	public class GetExpertInfoAppService : IGetExpertInfoAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExpertInfoAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<ExpertInfoDto>> Run(long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.ExpertRepository.IsExistAsync(e => e.UserId == userId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Expert), userId);
				return ValueResult<ExpertInfoDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var expert = await _unitOfWork.ExpertRepository.GetAsync(e => e.UserId == userId,cancellationToken);

			var result = UserMapper.MapToExpertInfo(expert);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<ExpertInfoDto>.Success(result,message);
		}
	}
}
