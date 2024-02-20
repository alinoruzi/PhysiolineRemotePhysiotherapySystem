using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.SpecializedTitleModels;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SpecializedTitleController : Controller
	{ 
		private readonly IGetSpecializedTitleAppService _get;
		private readonly IGetSpecializedTitlesPageListByAdminAppService _getPage;
		private readonly IAddSpecializedTitleByAdminAppService _add;
		private readonly IDeleteSpecializedTitleByAdminAppService _delete;
		private readonly IEditSpecializedTitleByAdminAppService _edit;


		public SpecializedTitleController(IGetSpecializedTitleAppService get, 
			IGetSpecializedTitlesPageListByAdminAppService getPage, 
			IAddSpecializedTitleByAdminAppService add, 
			IDeleteSpecializedTitleByAdminAppService delete, 
			IEditSpecializedTitleByAdminAppService edit)
		{
			_get = get;
			_getPage = getPage;
			_add = add;
			_delete = delete;
			_edit = edit;
		}
		
		
		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] uint pageNumber = 1,
			[FromQuery] uint pageSize = 10)
		{
			var exerciseCategories = await _getPage.Run((int)pageNumber, (int)pageSize, cancellationToken);

			var viewModel = new SpecializedTitleGetPageListViewModel()
			{
				Items = exerciseCategories,
				PageNumber = (int)pageNumber,
				PageSize = (int)pageSize,
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string,
			};

			TempData["pageNumber"] = viewModel.PageNumber;
			TempData["pageSize"] = viewModel.PageSize;

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(AddSpecializedTitleDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				TempData["operationResult"] = false;
				TempData["message"] = "ساختار داده ای ارسال شده معتبر نیست. لطفا مجددا تلاش کنید.";
				return RedirectToAction(nameof(PageList),
					new
					{
						pageNumber = TempData["pageNumber"],
						pageSize = TempData["pageSize"],
					});
			}
			
			long userId = long.Parse(HttpContext.User.Claims.First(c => c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;

			return RedirectToAction(nameof(PageList),
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"],
				});
		}
		
		[HttpPost]
		public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction(nameof(PageList),
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
				});
		}
		
		[HttpPost]
		public async Task<IActionResult> EditCategory(EditSpecializedTitleDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				TempData["operationResult"] = false;
				TempData["message"] = "ساختار داده ای ارسال شده معتبر نیست. لطفا مجددا تلاش کنید.";
				return RedirectToAction(nameof(PageList),
					new
					{
						pageNumber = TempData["pageNumber"],
						pageSize = TempData["pageSize"], 
					});
			}
			
			var result = await _edit.Run(dto, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;

			return RedirectToAction(nameof(PageList),
				new
				{
					pageNumber = TempData["pageNumber"],
					pageSize = TempData["pageSize"], 
				});
			
		}
	}
}
