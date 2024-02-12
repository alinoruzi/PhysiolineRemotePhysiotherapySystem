using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/admin/[controller]/")]
	[ApiController]
	public class ExerciseController : ControllerBase
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
		public async Task<ActionResult<List<GetExerciseListItemByAdminDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
			=> await _getPage.Run(pageNumber, pageSize, cancellationToken);

		[HttpGet("{id}")]
		public async Task<ActionResult<GetExerciseByAdminDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<ActionResult<List<SearchResultExerciseDto>>> Search(
			[FromQuery] SearchInputExerciseDto dto,
			CancellationToken cancellationToken)
			=> await _search.Run(dto, cancellationToken);

		[HttpPost]
		public async Task<ActionResult> Add(AddExerciseDto dto, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditExerciseDto dto, CancellationToken cancellationToken)
		{
			var result = await _edit.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
