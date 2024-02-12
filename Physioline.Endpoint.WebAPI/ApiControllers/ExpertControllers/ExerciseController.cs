using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert")]
	[Route("api/expert/[controller]/")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private readonly IAddExerciseByExpertAppService _add;
		private readonly IDeleteExerciseByExpertAppService _delete;
		private readonly IEditExerciseByExpertAppService _edit;
		private readonly IGetExerciseByExpertAppService _get;
		private readonly IGetGlobalExercisesPageListByExpertAppService _getGlobalPage;
		private readonly IGetSpecificExercisesPageListByExpertAppService _getSpecificPage;
		private readonly ISearchExerciseByExpertAppService _search;

		public ExerciseController(IGetGlobalExercisesPageListByExpertAppService getGlobalPage,
			IGetSpecificExercisesPageListByExpertAppService getSpecificPage,
			IGetExerciseByExpertAppService get,
			ISearchExerciseByExpertAppService search,
			IAddExerciseByExpertAppService add,
			IEditExerciseByExpertAppService edit,
			IDeleteExerciseByExpertAppService delete)
		{
			_getGlobalPage = getGlobalPage;
			_getSpecificPage = getSpecificPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
		}


		[HttpGet]
		public async Task<ActionResult<List<GetExerciseListItemByExpertDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] bool global = false,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);

			if (global)
				return await _getGlobalPage.Run(pageNumber, pageSize, cancellationToken);

			return await _getSpecificPage.Run(pageNumber, pageSize, userId, cancellationToken);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetExerciseByExpertDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _get.Run(id, userId, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<ActionResult<List<SearchResultExerciseDto>>> Search(
			[FromQuery] SearchInputExerciseDto dto,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			return await _search.Run(dto, userId, cancellationToken);
		}

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
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _edit.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _delete.Run(id, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
