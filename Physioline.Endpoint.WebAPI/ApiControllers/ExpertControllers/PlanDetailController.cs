using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Route("api/expert/plan-detail")]
	[ApiController]
	public class PlanDetailController : ControllerBase
	{
		private readonly IGetPlanDetailsByExpertAppService _get;
		private readonly IAddPlanDetailByExpertAppService _add;
		private readonly IEditPlanDetailByExpertAppService _edit;
		private readonly IDeletePlanDetailByExpertAppService _delete;

		public PlanDetailController(IGetPlanDetailsByExpertAppService get,
			IAddPlanDetailByExpertAppService add,
			IEditPlanDetailByExpertAppService edit,
			IDeletePlanDetailByExpertAppService delete)
		{
			_get = get;
			_add = add;
			_edit = edit;
			_delete = delete;
		}
		
		[HttpGet("{planId}")]
		public async Task<List<GetPlanDetailDto>> Get(long planId,
			CancellationToken cancellationToken)
		{
			long userId = 2;
			return await _get.Run(planId, userId, cancellationToken);
		}
		
		[HttpPost]
		public async Task<ActionResult> Add(AddPlanDetailDto dto,CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _add.Run(dto, userId, cancellationToken); 
			return StatusCode(result,result.Message);
		}
		
		[HttpPut]
		public async Task<ActionResult> Edit(EditPlanDetailDto dto, CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _edit.Run(dto,userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _delete.Run(id,userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
