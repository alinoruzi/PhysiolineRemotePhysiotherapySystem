using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
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
				    => u.Email == dto.Email && u.Mobile == dto.Mobile ,cancellationToken))
			{
				message = ResultMessage.CustomMessage($"The email and mobile number don't match.");
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}
			
			var user = await _unitOfWork.UserRepository
				.GetAsync(u => u.Email == dto.Email,cancellationToken);
			
			if (user.IsRegistered)
			{
				message = ResultMessage.CustomMessage($"The user is already registered.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			
			if (user.UserRole != UserRole.Client)
			{
				message = ResultMessage.CustomMessage($"User role of the target user is not allowed.");
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

			message = ResultMessage.CustomMessage($"User with id: {user.Id} successfully created and verified");

			return OperationResult.Success(message);
		}
	}
}
