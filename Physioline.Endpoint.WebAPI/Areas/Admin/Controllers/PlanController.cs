using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Queries;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.PlanModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PlanController : Controller
	{
		private readonly IGetPlansPageListByAdminAppService _getPage;
		private readonly IGetPlanDetailsByAdminAppService _getDetails;
		private readonly IDeletePlanByAdminAppService _delete;
		private readonly IGetPlanByAdminAppService _get;
		private readonly IGetCollectionByAdminAppService _getCollection;
		private readonly IGetUserInfoAppService _getUserInfo;
		private readonly IGetExpertInfoAppService _getExpertInfo;

		public PlanController(IGetPlansPageListByAdminAppService getPage,
			IGetPlanDetailsByAdminAppService getDetails,
			IDeletePlanByAdminAppService delete, 
			IGetPlanByAdminAppService get,
			IGetCollectionByAdminAppService getCollection, 
			IGetUserInfoAppService getUserInfo, 
			IGetExpertInfoAppService getExpertInfo)
		{
			_getPage = getPage;
			_getDetails = getDetails;
			_delete = delete;
			_get = get;
			_getCollection = getCollection;
			_getUserInfo = getUserInfo;
			_getExpertInfo = getExpertInfo;
		}
		
		
		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] uint pageNumber = 1,
			[FromQuery] uint pageSize = 10)
		{
			var plans = await _getPage.Run((int)pageNumber, (int)pageSize, cancellationToken);

			var viewModel = new PlanGetPageListViewModel()
			{
				Items = plans,
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

			var detailsViewModel = new List<PlanDetailItemViewModel>();

			foreach (var detail in details)
			{
				var collectionResult = await _getCollection.Run(detail.CollectionId, cancellationToken);

				if (!collectionResult)
				{
					TempData["operationResult"] = (bool)collectionResult;
					TempData["message"] = collectionResult.Message;
					return RedirectToAction(nameof(PageList));
				}
				
				detailsViewModel.Add(new PlanDetailItemViewModel()
				{
					Id = detail.Id,
					CollectionId = collectionResult.Value.Id,
					CollectionTitle = collectionResult.Value.Title,
					CollectionShortDescription = collectionResult.Value.ShortDescription,
					CollectionIsGlobal = collectionResult.Value.IsGlobal,
					Priority = detail.Priority,
					WeekDays = detail.WeekDays
				});
			}

			var expertInfoResult = await _getExpertInfo.Run(result.Value.CreatorUserId, cancellationToken);
			if (!expertInfoResult)
			{
				TempData["operationResult"] = (bool)expertInfoResult;
				TempData["message"] = expertInfoResult.Message;
				return RedirectToAction(nameof(PageList));
			}
			
			var expertUserInfoResult = await _getUserInfo.Run(result.Value.CreatorUserId, cancellationToken);
			if (!expertUserInfoResult)
			{
				TempData["operationResult"] = (bool)expertUserInfoResult;
				TempData["message"] = expertUserInfoResult.Message;
				return RedirectToAction(nameof(PageList));
			}
			
			var clientUserInfoResult = await _getUserInfo.Run(result.Value.ClientUserId, cancellationToken);
			if (!clientUserInfoResult)
			{
				TempData["operationResult"] = (bool)clientUserInfoResult;
				TempData["message"] = clientUserInfoResult.Message;
				return RedirectToAction(nameof(PageList));
			}

			var viewModel = new PlanGetViewModel()
			{
				Plan = result.Value,
				Details = detailsViewModel,
				ExpertInfo = expertInfoResult.Value,
				ExpertUserInfo = expertUserInfoResult.Value,
				ClientUserInfo = clientUserInfoResult.Value,
				OperationResult = TempData["operationResult"] as bool?,
				Message = TempData["message"] as string
			};

			return View(viewModel);
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
