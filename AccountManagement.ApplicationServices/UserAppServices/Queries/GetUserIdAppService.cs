using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.UserAppServices.Queries
{
	public class GetUserIdAppService : IGetUserIdAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetUserIdAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<long>> Run(string identifier, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository.IsExistAsync(u => u.Identifier == identifier,cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(User),0);
				return ValueResult<long>.Failed(message, HttpStatusCode.NotFound);
			}

			var user = await _unitOfWork.UserRepository.GetAsync(u => u.Identifier == identifier,cancellationToken);
			
			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<long>.Success(user.Id, message);
		}

		public async Task<ValueResult<long>> Run(EmailDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository.IsExistAsync(u => u.Email == dto.Email,cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(User),0);
				return ValueResult<long>.Failed(message, HttpStatusCode.NotFound);
			}
			
			var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == dto.Email,cancellationToken);
			
			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<long>.Success(user.Id, message);
		}
	}
}
