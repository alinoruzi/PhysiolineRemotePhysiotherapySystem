using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly IGetPlanByClientAppService _get;
		private readonly IGetAllPlansByClientAppService _getAll;
		public PlanController(IGetAllPlansByClientAppService getAll,
			IGetPlanByClientAppService get)
		{
			_getAll = getAll;
			_get = get;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetPlanByClientDto>>> GetAll(CancellationToken cancellationToken)
		{
			long userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			return await _getAll.Run(userId, cancellationToken);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPlanByClientDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			long userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _get.Run(id, userId, cancellationToken);
			return result ? Ok(result.Value) : StatusCode(result, result.Message);
		}
	}
}
