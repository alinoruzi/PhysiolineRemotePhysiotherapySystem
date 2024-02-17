using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Queries
{
	public class LoginUserAppService : ILoginUserAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public LoginUserAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<LoginResultDto>> Run(LoginInputDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			dto.Username = dto.Username.ToLower();
			if (!await _unitOfWork.UserRepository
				    .IsExistAsync(u => u.Email == dto.Username, cancellationToken))
			{
				message = ResultMessage.IncorrectUsernamePassword();
				return ValueResult<LoginResultDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == dto.Username, cancellationToken);

			var hashedPassword = HasherService.HashString(dto.Password);

			if (!user.IsRegistered)
			{
				message = ResultMessage.RegistrationNotCompleted();
				return ValueResult<LoginResultDto>.Failed(message, HttpStatusCode.NotFound);
			}

			if (user.Password != hashedPassword)
			{
				message = ResultMessage.IncorrectUsernamePassword();
				return ValueResult<LoginResultDto>.Failed(message, HttpStatusCode.NotFound);
			}

			if (!user.IsConfirmed)
			{
				message = ResultMessage.UserIsNotConfirmed();
				return ValueResult<LoginResultDto>.Failed(message, HttpStatusCode.BadRequest);
			}

			var result = UserMapper.MapToLoginResult(user);
			
			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<LoginResultDto>.Success(result, message);
		}
	}
}
