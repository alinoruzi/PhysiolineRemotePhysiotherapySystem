using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Commands
{
	public class ChangeUserPasswordByAdminAppService : IChangeUserPasswordByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ChangeUserPasswordByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(ChangeUserPasswordBtAdminDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			
			if (!await _unitOfWork.UserRepository
				    .IsExistAsync(u => u.Id == dto.UserId,cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(User), dto.UserId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var user = await _unitOfWork.UserRepository.GetAsync(dto.UserId, cancellationToken);

			user.Password = HasherService.HashString(dto.Password);
			
			_unitOfWork.UserRepository.Update(user);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(User), dto.UserId);
			return OperationResult.Success(message);
		}
	}
}
