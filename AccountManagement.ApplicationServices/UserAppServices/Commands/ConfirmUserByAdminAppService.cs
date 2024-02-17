using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Commands
{
	public class ConfirmUserByAdminAppService : IConfirmUserByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ConfirmUserByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository.IsExistAsync(u => u.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(User), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var user = await _unitOfWork.UserRepository.GetAsync(id,cancellationToken);
			
			if (!user.IsRegistered)
			{
				message = ResultMessage.RegistrationNotCompleted();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			if (user.IsConfirmed)
			{
				message = ResultMessage.CustomMessage("کاربر قبلا غیرفعال شده است.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			user.IsConfirmed = true;
			
			_unitOfWork.UserRepository.Update(user);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.CustomMessage("کاربر با موفقیت تایید شد.");
			return OperationResult.Success(message);
		}
	}
}
