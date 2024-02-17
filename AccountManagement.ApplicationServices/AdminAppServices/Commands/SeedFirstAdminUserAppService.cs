using AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.AdminAppServicesContracts.DTOs;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.AdminAppServices.Commands
{
	public class SeedFirstAdminUserAppService : ISeedFirstAdminUserAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRegisterAdminByAdminAppService _registerAdmin;
		public SeedFirstAdminUserAppService(IUnitOfWork unitOfWork, 
			IRegisterAdminByAdminAppService registerAdmin)
		{
			_unitOfWork = unitOfWork;
			_registerAdmin = registerAdmin;
		}

		public async Task<OperationResult> Run(CancellationToken cancellationToken)
		{
			ResultMessage message;
			var adminDto = new RegisterAdminDto()
			{
				Email = "firstAdmin@first.ir",
				Mobile = "09100000000",
				FirstName = "مدیر",
				LastName = "سیستم",
				Gender = 1,
				Password = "admin1234",
			};

			if ((await _unitOfWork.AdminRepository.GetAllAsync(cancellationToken)).Any())
			{
				message = ResultMessage.CustomMessage("مدیر سیستم قبلا تعریف شده است.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			return await _registerAdmin.Run(adminDto,0, cancellationToken);
		}
	}
}
