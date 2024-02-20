using AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.AdminAppServicesContracts.DTOs;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.AdminAppServices.Commands
{
	public class RegisterAdminByAdminAppService : IRegisterAdminByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public RegisterAdminByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(RegisterAdminDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (await _unitOfWork.UserRepository
				    .IsExistAsync(u => u.Email == dto.Email || u.Mobile == dto.Mobile,cancellationToken))
			{
				message = ResultMessage.CustomMessage("ایمیل یا شماره موبایل وارد شده تکراری است.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			
			var user = new User
			{
				Email = dto.Email,
				Mobile = dto.Mobile,
				Password = HasherService.HashString(dto.Password),
				CreatorUserId = userId,
				UserRole = UserRole.Admin,
				IsConfirmed = true,
				IsRegistered = true,
			};

			await _unitOfWork.UserRepository.CreateAsync(user, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);

			var admin = new Admin
			{
				UserId = user.Id,
				CreatorUserId = userId,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Gender = (Gender)dto.Gender,
			};

			await _unitOfWork.AdminRepository.CreateAsync(admin, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyAdded(nameof(User), user.Id);
			return OperationResult.Success(message);
		}
	}
}
