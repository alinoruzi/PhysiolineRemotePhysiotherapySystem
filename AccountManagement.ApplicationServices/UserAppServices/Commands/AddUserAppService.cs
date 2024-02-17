using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Commands
{
	public class AddUserAppService : IAddUserAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddUserAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(AddUserDto dto,
			UserRole role, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (await _unitOfWork.UserRepository
				    .IsExistAsync(u
					    => u.Email == dto.Email || u.Mobile == dto.Mobile, cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(User), nameof(User.Email) + " or " + nameof(User.Mobile));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var user = UserMapper.Map(dto, role, userId);

			await _unitOfWork.UserRepository.CreateAsync(user, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(User), user.Id);
			return OperationResult.Success(message);
		}
	}
}
