using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Queries
{
	public class GetUserInfoAppService : IGetUserInfoAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetUserInfoAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<UserInfoDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository
				    .IsExistAsync(u => u.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(User),id);
				return ValueResult<UserInfoDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var user = await _unitOfWork.UserRepository.GetAsyncIncludePerson(id, cancellationToken);

			if (!user.IsRegistered)
			{
				message = ResultMessage.RegistrationNotCompleted();
				return ValueResult<UserInfoDto>.Failed(message, HttpStatusCode.BadRequest);
			}

			var dto = UserMapper.MapToInfo(user, user.Person);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<UserInfoDto>.Success(dto, message);
		}
	}
}
