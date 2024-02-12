using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize("Expert")]
	[Route("api/expert/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly IAddPlanByExpertAppService _add;
		private readonly IDeletePlanByExpertAppService _delete;
		private readonly IEditPlanByExpertAppService _edit;
		private readonly IGetPlanByExpertAppService _get;
		private readonly IGetPlansListByExpertAppService _getAll;


		public PlanController(IGetPlansListByExpertAppService getAll,
			IGetPlanByExpertAppService get,
			IAddPlanByExpertAppService add,
			IEditPlanByExpertAppService edit,
			IDeletePlanByExpertAppService delete)
		{
			_getAll = getAll;
			_get = get;
			_add = add;
			_edit = edit;
			_delete = delete;
		}


		[HttpGet]
		public async Task<ActionResult<List<GetPlanByExpertDto>>> GetAll(CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			return await _getAll.Run(userId, cancellationToken);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPlanByExpertDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _get.Run(id, userId, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpPost]
		public async Task<ActionResult> Add(AddPlanDto dto, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditPlanDto dto, CancellationToken cancellationToken)
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
