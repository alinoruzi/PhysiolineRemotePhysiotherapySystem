using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
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
			long userId = 3;
			return await _getAll.Run(planId, userId, cancellationToken);
		}
		
	}
}
