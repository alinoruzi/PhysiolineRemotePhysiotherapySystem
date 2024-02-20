using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionCategoryModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CollectionCategoryController : Controller
	{
		private readonly IGetCollectionCategoryAppService _get;
		private readonly IGetCollectionCategoriesPageListByAdminAppService _getPage;
		private readonly IAddCollectionCategoryByAdminAppService _add;
		private readonly IDeleteCollectionCategoryByAdminAppService _delete;
		private readonly IEditCollectionCategoryByAdminAppService _edit;
		public CollectionCategoryController(IGetCollectionCategoryAppService get, 
			IGetCollectionCategoriesPageListByAdminAppService getPage, 
			IAddCollectionCategoryByAdminAppService add, 
			IDeleteCollectionCategoryByAdminAppService delete, 
			IEditCollectionCategoryByAdminAppService edit)
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
			var collectionCategories = await _getPage.Run((int)pageNumber, (int)pageSize, cancellationToken);

			var viewModel = new CollectionCategoryGetPageListViewModel()
			{
				Items = collectionCategories,
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
		public async Task<IActionResult> Create(AddCollectionCategoryDto dto, CancellationToken cancellationToken)
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
		public async Task<IActionResult> EditCategory(EditCollectionCategoryDto dto, CancellationToken cancellationToken)
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
