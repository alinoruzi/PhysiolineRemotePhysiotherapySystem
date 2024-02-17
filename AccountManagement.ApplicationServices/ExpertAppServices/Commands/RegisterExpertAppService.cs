using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.GeneralServices;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.ExpertAppServices.Commands
{
	public class RegisterExpertAppService : IRegisterExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public RegisterExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(RegisterExpertDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.UserRepository.IsExistAsync(u
				    => u.Email == dto.Email && u.Mobile == dto.Mobile ,cancellationToken))
			{
				message = ResultMessage.EmailMobileNotMatchForRegistration();
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}
			
			if (await _unitOfWork.ExpertRepository.IsExistAsync(u => u.NationalCode == dto.NationalCode,cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(Expert), nameof(Expert.NationalCode));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			if (await _unitOfWork.ExpertRepository.IsExistAsync(u => u.MedicalSystemCode == dto.MedicalSystemCode,cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(Expert), nameof(Expert.MedicalSystemCode));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			var user = await _unitOfWork.UserRepository
				.GetAsync(u => u.Email == dto.Email,cancellationToken);
			
			if (user.IsRegistered)
			{
				message = ResultMessage.UserAlreadyRegistered();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}
			
			if (user.UserRole != UserRole.Expert)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			if (!await _unitOfWork.SpecializedTitleRepository
				    .IsExistAsync(st => st.Id == dto.SpecializedTitleId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(SpecializedTitle), dto.SpecializedTitleId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var expert = UserMapper.MapToExpert(dto, user.Id);
			
			string hashedPassword = HasherService.HashString(dto.Password);

			await _unitOfWork.ExpertRepository.CreateAsync(expert, cancellationToken);

			user.Person = expert;
			user.IsRegistered = true;
			user.Password = hashedPassword;

			_unitOfWork.UserRepository.Update(user);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyRegistered();

			return OperationResult.Success(message);
		}
	}
}
