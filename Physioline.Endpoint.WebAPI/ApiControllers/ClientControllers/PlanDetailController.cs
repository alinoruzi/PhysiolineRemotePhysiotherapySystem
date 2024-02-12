using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/plan-detail")]
	[ApiController]
	public class PlanDetailController : ControllerBase
	{
		private readonly IGetAllPlanDetailsByClientAppService _getAll;
		public PlanDetailController(IGetAllPlanDetailsByClientAppService getAll)
		{
			_getAll = getAll;
		}


		[HttpGet("{planId}")]
		public async Task<ActionResult<List<GetPlanDetailDto>>> GetAll(long planId,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			return await _getAll.Run(planId, userId, cancellationToken);
		}
	}
}
