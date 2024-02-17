using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.UserManagerModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UserManagerController : Controller
	{
		private readonly IGetUsersPageListByAdminAppService _getPage;
		private readonly IConfirmUserByAdminAppService _confirm;
		private readonly IDeactivateUserByAdminAppService _deactivate;
		private readonly IChangeUserPasswordByAdminAppService _changeUserPassword;
		
		public UserManagerController(IGetUsersPageListByAdminAppService getPage, 
			IConfirmUserByAdminAppService confirm,
			IDeactivateUserByAdminAppService deactivate, 
			IChangeUserPasswordByAdminAppService changeUserPassword)
		{
			_getPage = getPage;
			_confirm = confirm;
			_deactivate = deactivate;
			_changeUserPassword = changeUserPassword;

		}
		
		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] string userRole = "Expert",
			[FromQuery] uint pageNumber = 1,
			[FromQuery] uint pageSize = 10)
		{
			if (!Enum.TryParse(typeof(UserRole), userRole, out object role))
			{
				role = UserRole.Client;
			}
			var users = await _getPage.Run((UserRole)role, (int)pageNumber, (int)pageSize, cancellationToken);
			
			var viewModel = new UserGetPageListViewModel()
			{
				Items = users,
				PageNumber = (int)pageNumber,
				PageSize = (int)pageSize,
				Role = role.ToString(),
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string,
			};

			TempData["userRole"] = viewModel.Role;
			TempData["pageNumber"] = viewModel.PageNumber;
			TempData["pageSize"] = viewModel.PageSize;
			
			return View(viewModel);
		}
		
		
		[HttpGet]
		public async Task<IActionResult> ConfirmUser(long userId, CancellationToken cancellationToken)
		{
			var result = await _confirm.Run(userId, cancellationToken);
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction("PageList",
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
					userRole = TempData["userRole"]
				});
		}
		
		[HttpGet]
		public async Task<IActionResult> DeactivateUser(long userId, CancellationToken cancellationToken)
		{
			var result = await _deactivate.Run(userId, cancellationToken);
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction("PageList",
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
					userRole = TempData["userRole"]
				});
		}
		
		[HttpPost]
		public async Task<IActionResult> ChangeUserPassword(ChangeUserPasswordBtAdminDto dto,
			CancellationToken cancellationToken)
		{
			var result = await _changeUserPassword.Run(dto, cancellationToken);
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction("PageList",
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
					userRole = TempData["userRole"]
				});
		}
		
	}
}
