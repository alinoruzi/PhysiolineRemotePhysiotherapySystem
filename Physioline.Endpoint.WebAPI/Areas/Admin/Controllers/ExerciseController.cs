using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ExerciseController : Controller
	{
		private readonly IAddExerciseByAdminAppService _add;
		private readonly IDeleteExerciseByAdminAppService _delete;
		private readonly IEditExerciseByAdminAppService _edit;
		private readonly IGetExerciseByAdminAppService _get;
		private readonly IGetExercisesPageListByAdminAppService _getPage;
		private readonly ISearchExerciseByAdminAppService _search;
		private readonly ISearchExerciseCategoryAppService _searchCategory;
		private readonly IGetUserInfoAppService _getUserInfo;
		private readonly IGetExerciseCategoryAppService _getCategory;

		public ExerciseController(IGetExercisesPageListByAdminAppService getPage,
			IGetExerciseByAdminAppService get,
			ISearchExerciseByAdminAppService search,
			IAddExerciseByAdminAppService add,
			IEditExerciseByAdminAppService edit,
			IDeleteExerciseByAdminAppService delete, 
			ISearchExerciseCategoryAppService searchCategory, 
			IGetUserInfoAppService getUserInfo, 
			IGetExerciseCategoryAppService getCategory)
		{
			_getPage = getPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
			_searchCategory = searchCategory;
			_getUserInfo = getUserInfo;
			_getCategory = getCategory;
		}

		
		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] uint pageNumber = 1,
			[FromQuery] uint pageSize = 10)
		{
			var exercises = await _getPage.Run((int)pageNumber, (int)pageSize, cancellationToken);

			var viewModel = new ExerciseGetPageListViewModel()
			{
				Items = exercises,
				PageNumber = (int)pageNumber,
				PageSize = (int)pageSize,
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string,
			};

			TempData["pageNumber"] = viewModel.PageNumber;
			TempData["pageSize"] = viewModel.PageSize;

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> GetSingle(long id, CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			if (!result)
			{
				TempData["operationResult"] = (bool)result;
				TempData["message"] = result.Message;
				return RedirectToAction(nameof(PageList));
			}

			var userInfoResult = await _getUserInfo.Run(result.Value.CreatorUserId, cancellationToken);
			if (!userInfoResult)
			{
				TempData["operationResult"] = (bool)userInfoResult;
				TempData["message"] = userInfoResult.Message;
				return RedirectToAction(nameof(PageList));
			}
			
			var categoryResult = await _getCategory.Run(result.Value.CategoryId, cancellationToken);
			if (!categoryResult)
			{
				TempData["operationResult"] = (bool)categoryResult;
				TempData["message"] = categoryResult.Message;
				return RedirectToAction(nameof(PageList));
			}

			var viewModel = new ExerciseGetViewModel()
			{
				Exercise = result.Value,
				CategoryTitle = categoryResult.Value.Title,
				CreatorUserInfo = userInfoResult.Value,
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string,
			};
			
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> CreateExercise(CancellationToken cancellationToken)
		{
			var categories = await _searchCategory.Run(new ExerciseCategorySearchInputDto() { Title = null }, cancellationToken);
			var listItems = categories.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title });
			ViewData["categories"] = listItems as IEnumerable<SelectListItem>;
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> CreateExercise(AddExerciseDto dto,CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				var categories = await _searchCategory.Run(new ExerciseCategorySearchInputDto() { Title = null }, cancellationToken);
				var listItems = categories.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title });
				ViewData["categories"] = listItems as IEnumerable<SelectListItem>;
				return View(dto);
			}

			long userId = long.Parse(HttpContext.User.Claims.First(c => c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;

			return RedirectToAction(nameof(PageList));
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
	}
}
