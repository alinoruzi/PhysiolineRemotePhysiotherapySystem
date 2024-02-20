using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.UserManagerModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.Domain.Entities;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UserManagerController : Controller
	{
		private readonly IGetUsersPageListByAdminAppService _getPage;
		private readonly IConfirmUserByAdminAppService _confirm;
		private readonly IDeactivateUserByAdminAppService _deactivate;
		private readonly IChangeUserPasswordByAdminAppService _changeUserPassword;
		private readonly IAddUserAppService _addUser;
		
		public UserManagerController(IGetUsersPageListByAdminAppService getPage, 
			IConfirmUserByAdminAppService confirm,
			IDeactivateUserByAdminAppService deactivate, 
			IChangeUserPasswordByAdminAppService changeUserPassword, 
			IAddUserAppService addUser)
		{
			_getPage = getPage;
			_confirm = confirm;
			_deactivate = deactivate;
			_changeUserPassword = changeUserPassword;
			_addUser = addUser;

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

		[HttpPost]
		public async Task<IActionResult> PreRegisterUser([Bind] PreRegisterViewModel viewModel, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				TempData["operationResult"] = false;
				TempData["message"] = "ساختار داده ای ارسال شده معتبر نیست. لطفا مجددا تلاش کنید.";
				return RedirectToAction("PageList",
					new
					{
						pageNumber = TempData["pageNumber"],
						pageSize = TempData["pageSize"], 
						userRole = TempData["userRole"]
					});
			}

			var dto = new AddUserDto()
			{
				Email = viewModel.Email,
				Mobile = viewModel.Mobile
			};
			
			long userId = long.Parse(HttpContext.User.Claims.First(c => c.Type == "userId").Value);
			
			var result = await _addUser.Run(dto,(UserRole)viewModel.RoleNumber, userId, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction(nameof(PageList),
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
					userRole = TempData["userRole"]
				});
		}
		
	}
}
