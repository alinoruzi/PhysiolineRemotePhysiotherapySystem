using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/admin/plan-detail")]
	[ApiController]
	public class PlanDetailController : ControllerBase
	{
		private readonly IGetPlanDetailsByAdminAppService _get;
		public PlanDetailController(IGetPlanDetailsByAdminAppService get)
		{
			_get = get;
		}

		[HttpGet("{planId}")]
		public async Task<List<GetPlanDetailDto>> Get(long planId,
			CancellationToken cancellationToken)
			=> await _get.Run(planId, cancellationToken);
	}
}
