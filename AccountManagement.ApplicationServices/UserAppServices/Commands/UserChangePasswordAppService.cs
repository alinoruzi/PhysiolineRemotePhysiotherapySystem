using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Commands
{
	public class UserChangePasswordAppService : IUserChangePasswordAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserChangePasswordAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(ChangePasswordDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);

			if (!user.IsRegistered)
			{
				message = ResultMessage.RegistrationNotCompleted();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var hashedOldPassword = HasherService.HashString(dto.OldPassword);
			var hashedNewPassword = HasherService.HashString(dto.NewPassword);

			if (hashedOldPassword != user.Password)
			{
				message = ResultMessage.IncorrectUsernamePassword();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			user.Password = hashedNewPassword;
			
			_unitOfWork.UserRepository.Update(user);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.CustomMessage("رمز عبور شما با موفقیت تغییر یافت.");
			return OperationResult.Success(message);
		}
	}
}
