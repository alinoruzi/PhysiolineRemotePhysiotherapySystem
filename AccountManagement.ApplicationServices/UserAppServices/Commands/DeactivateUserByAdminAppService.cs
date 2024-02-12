using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Commands
{
	public class DeactivateUserByAdminAppService : IDeactivateUserByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeactivateUserByAdminAppService(IUnitOfWork unitOfWork)
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
				message = ResultMessage.CustomMessage("The user has not completed registration.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			if (user.IsConfirmed)
			{
				message = ResultMessage.CustomMessage("The user has already been confirmed.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			user.IsConfirmed = false;
			
			_unitOfWork.UserRepository.Update(user);

			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.CustomMessage("User successfully deactivated.");
			return OperationResult.Success(message);
		}
	}
}
