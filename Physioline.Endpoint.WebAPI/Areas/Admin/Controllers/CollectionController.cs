using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CollectionController : Controller
	{
		private readonly IGetCollectionsPageListByAdminAppService _getPage;
		private readonly IDeleteCollectionByAdminAppService _delete;
		private readonly IGetCollectionByAdminAppService _get;
		private readonly IGetCollectionDetailsByAdminAppService _getDetails;
		private readonly IGetExerciseByAdminAppService _getExercise;
		private readonly IDeleteCollectionDetailByAdminAppService _deleteDetail;
		private readonly IAddCollectionByAdminAppService _add;
		private readonly ISearchCollectionCategoryAppService _searchCategory;
		private readonly IGetUserInfoAppService _getUserInfo;
		private readonly IGetCollectionCategoryAppService _getCategory;
		private readonly IAddCollectionDetailByAdminAppService _addCollectionDetail;
		private readonly ISearchExerciseByAdminAppService _searchExercise;
		private readonly IEditCollectionByAdminAppService _edit;


		public CollectionController(IGetCollectionsPageListByAdminAppService getPage,
			IDeleteCollectionByAdminAppService delete, 
			IGetCollectionByAdminAppService get, 
			IGetCollectionDetailsByAdminAppService getDetails, 
			IGetExerciseByAdminAppService getExercise,
			IDeleteCollectionDetailByAdminAppService deleteDetail, IAddCollectionByAdminAppService add, 
			ISearchCollectionCategoryAppService searchCategory, IGetUserInfoAppService getUserInfo,
			IGetCollectionCategoryAppService getCategory,
			IAddCollectionDetailByAdminAppService addCollectionDetail, 
			ISearchExerciseByAdminAppService searchExercise, 
			IEditCollectionByAdminAppService edit)
		{
			_getPage = getPage;
			_delete = delete;
			_get = get;
			_getDetails = getDetails;
			_getExercise = getExercise;
			_deleteDetail = deleteDetail;
			_add = add;
			_searchCategory = searchCategory;
			_getUserInfo = getUserInfo;
			_getCategory = getCategory;
			_addCollectionDetail = addCollectionDetail;
			_searchExercise = searchExercise;
			_edit = edit;
		}
		
		
		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] uint pageNumber = 1,
			[FromQuery] uint pageSize = 10)
		{
			var collections = await _getPage.Run((int)pageNumber, (int)pageSize, cancellationToken);

			var viewModel = new CollectionGetPageListViewModel()
			{
				Items = collections,
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
			
			var details = await _getDetails.Run(id, cancellationToken);

			var detailsViewModel = new List<CollectionDetailItemViewModel>();

			foreach (var item in details)
			{
				var exerciseResult = await _getExercise.Run(item.ExerciseId, cancellationToken);

				if (!exerciseResult)
				{
					TempData["operationResult"] = (bool)exerciseResult;
					TempData["message"] = exerciseResult.Message;
					return RedirectToAction(nameof(PageList));
				}
				
				detailsViewModel.Add(new CollectionDetailItemViewModel()
				{
					Id = item.Id,
					Priority = item.Priority,
					ExerciseId = item.ExerciseId,
					NumberPerDuration = item.NumberPerDuration,
					SecondsOfDuration = item.SecondsOfDuration,
					ExerciseIsGlobal = exerciseResult.Value.IsGlobal,
					ExerciseTitle = exerciseResult.Value.Title,
					ExerciseShortDescription = exerciseResult.Value.ShortDescription,
					ExercisePicturePath = exerciseResult.Value.PicturePath
				});
			}
			
			var userResult = await _getUserInfo.Run(result.Value.CreatorUserId, cancellationToken);
			var categoryResult = await _getCategory.Run(result.Value.CategoryId, cancellationToken);

			if (!userResult)
			{
				TempData["operationResult"] = (bool)userResult;
				TempData["message"] = userResult.Message;
				return RedirectToAction(nameof(PageList));
			}
			
			if (!categoryResult)
			{
				TempData["operationResult"] = (bool)categoryResult;
				TempData["message"] = categoryResult.Message;
				return RedirectToAction(nameof(PageList));
			}
				
			var exercises = await _searchExercise.Run(new SearchInputExerciseDto() { Title = null }, cancellationToken);
			var exerciseListItems = exercises.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title });

			var categories = await _searchCategory.Run(new CollectionCategorySearchInputDto() { Title = null }, cancellationToken);
			var categoriesListItems = categories.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title });

			var viewModel = new CollectionGetViewModel()
			{
				Collection = result.Value,
				CategoryTitle = categoryResult.Value.Title,
				Exercises = exerciseListItems,
				Categories = categoriesListItems,
				CreatorUserInfo = userResult.Value,
				Items = detailsViewModel,
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string,
			};
			
			return View(viewModel);
		}


		[HttpGet]
		public async Task<IActionResult> CreateCollection(CancellationToken cancellationToken)
		{
			var categories = await _searchCategory.Run(new CollectionCategorySearchInputDto() { Title = null }, cancellationToken);
			var listItems = categories.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title });
			ViewData["categories"] = listItems as IEnumerable<SelectListItem>;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCollection(AddCollectionDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				var categories = await _searchCategory.Run(new CollectionCategorySearchInputDto() { Title = null }, cancellationToken);
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
		
		[HttpPost]
		public async Task<IActionResult> DeleteDetail(long id, long collectionId, CancellationToken cancellationToken)
		{
			var result = await _deleteDetail.Run(id, cancellationToken);
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;
			return RedirectToAction(nameof(GetSingle),new {id = collectionId});
		}

		[HttpPost]
		public async Task<IActionResult> CreateDetail(AddCollectionDetailDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				TempData["operationResult"] = false;
				TempData["message"] = "ساختار داده ای ارسال شده معتبر نیست. لطفا مجددا تلاش کنید.";
				return RedirectToAction(nameof(GetSingle), new {id = dto.CollectionId});
			}
			
			long userId = long.Parse(HttpContext.User.Claims.First(c => c.Type == "userId").Value);
			var result = await _addCollectionDetail.Run(dto, userId, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;

			return RedirectToAction(nameof(GetSingle), new {id = dto.CollectionId});
		}

		[HttpPost]
		public async Task<IActionResult> EditCollection(EditCollectionDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				TempData["operationResult"] = false;
				TempData["message"] = "ساختار داده ای ارسال شده معتبر نیست. لطفا مجددا تلاش کنید.";
				return RedirectToAction(nameof(GetSingle), new {id = dto.Id});
			}
			
			var result = await _edit.Run(dto, cancellationToken);
			
			TempData["operationResult"] = result.IsSuccess;
			TempData["message"] = result.Message;

			return RedirectToAction(nameof(GetSingle), new {id = dto.Id});
			
		}
	}
}
