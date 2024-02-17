using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	public class ExerciseController : Controller
	{
		private readonly IAddExerciseByAdminAppService _add;
		private readonly IDeleteExerciseByAdminAppService _delete;
		private readonly IEditExerciseByAdminAppService _edit;
		private readonly IGetExerciseByAdminAppService _get;
		private readonly IGetExercisesPageListByAdminAppService _getPage;
		private readonly ISearchExerciseByAdminAppService _search;

		public ExerciseController(IGetExercisesPageListByAdminAppService getPage,
			IGetExerciseByAdminAppService get,
			ISearchExerciseByAdminAppService search,
			IAddExerciseByAdminAppService add,
			IEditExerciseByAdminAppService edit,
			IDeleteExerciseByAdminAppService delete)
		{
			_getPage = getPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
		}

		[HttpGet]
		public async Task<IActionResult> PageList(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
		{
			var exercise = await _getPage.Run(pageNumber, pageSize, cancellationToken);
			var viewModel = new ExerciseGetPageListViewModel() { Exercises = exercise };
			viewModel.PageNumber = pageNumber;
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}
		
		// [HttpPost]
		// public async Task<ActionResult> Add(AddExerciseDto dto, CancellationToken cancellationToken)
		// {
		// 	long userId = 1;
		// 	var result = await _add.Run(dto, userId, cancellationToken);
		// 	return StatusCode(result, result.Message);
		// }
		//
		
		// [HttpGet("{id}")]
		// public async Task<ActionResult> Edit(long id, CancellationToken cancellationToken)
		// {
		// 	var result = await _get.Run(id, cancellationToken);
		// 	return View(result);
		// }
		//
		// [HttpPost]
		// public async Task<ActionResult> Edit(EditExerciseDto dto, CancellationToken cancellationToken)
		// {
		// 	var result = await _edit.Run(dto, cancellationToken);
		// 	return StatusCode(result, result.Message);
		// }
		
		
		//
		// [HttpDelete("{id}")]
		// public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		// {
		// 	var result = await _delete.Run(id, cancellationToken);
		// 	return StatusCode(result, result.Message);
		// }
	}
}
