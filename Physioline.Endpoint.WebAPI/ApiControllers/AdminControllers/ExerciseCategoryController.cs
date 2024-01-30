using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Route("api/admin/exercise-category/")]
	[ApiController]
	public class ExerciseCategoryController : ControllerBase
	{
		private readonly IAddExerciseCategoryByAdminAppService _add;
		private readonly IDeleteExerciseByAdminAppService _delete;
		private readonly IEditExerciseCategoryByAdminAppService _edit;
		private readonly IGetExerciseCategoryAppService _get;
		private readonly IGetExerciseCategoriesPageListByAdminAppService _getPage;
		private readonly ISearchExerciseCategoryAppService _search;
		public ExerciseCategoryController(IGetExerciseCategoriesPageListByAdminAppService getPage,
			IGetExerciseCategoryAppService get,
			ISearchExerciseCategoryAppService search,
			IAddExerciseCategoryByAdminAppService add,
			IEditExerciseCategoryByAdminAppService edit,
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
		public async Task<List<GetExerciseCategoryListItemDto>> GetAll(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
			=> await _getPage.Run(pageNumber, pageSize, cancellationToken);

		[HttpGet("{id}")]
		public async Task<ActionResult<GetExerciseCategoryDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<List<ExerciseCategorySearchResultDto>> Search(
			[FromQuery] ExerciseCategorySearchInputDto dto,
			CancellationToken cancellationToken)
			=> await _search.Run(dto, cancellationToken);

		[HttpPost]
		public async Task<ActionResult> Add(AddExerciseCategoryDto dto,
			CancellationToken cancellationToken)
		{
			long userId = 1;
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditExerciseCategoryDto dto,
			CancellationToken cancellationToken)
		{
			var result = await _edit.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id,
			CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
