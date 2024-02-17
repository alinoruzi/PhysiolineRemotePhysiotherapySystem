using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.ClientAppServices.Commands
{
	public class RegisterClientAppService : IRegisterClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public RegisterClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(RegisterClientDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository.IsExistAsync(u
				    => u.Email == dto.Username && u.Mobile == dto.Mobile ,cancellationToken))
			{
				message = ResultMessage.EmailMobileNotMatchForRegistration();
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			if (await _unitOfWork.ClientRepository.IsExistAsync(u => u.NationalCode == dto.NationalCode,cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(Client),nameof(Client.NationalCode));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			var user = await _unitOfWork.UserRepository
				.GetAsync(u => u.Email == dto.Username && u.Mobile == dto.Mobile,cancellationToken);
			
			if (user.IsRegistered)
			{
				message = ResultMessage.UserAlreadyRegistered();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			
			if (user.UserRole != UserRole.Client)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			var client = UserMapper.MapToClient(dto, user.Id);

			string hashedPassword = HasherService.HashString(dto.Password);

			await _unitOfWork.ClientRepository.CreateAsync(client, cancellationToken);

			user.Person = client;
			user.IsRegistered = true;
			user.IsConfirmed = true;
			user.Password = hashedPassword;

			_unitOfWork.UserRepository.Update(user);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyRegistered();

			return OperationResult.Success(message);
		}
	}
}
