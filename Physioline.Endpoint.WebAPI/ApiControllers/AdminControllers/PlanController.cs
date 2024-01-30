using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Route("api/admin/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly IDeletePlanByAdminAppService _delete;
		private readonly IGetPlansPageListByAdminAppService _getPage;

		public PlanController(IGetPlansPageListByAdminAppService getPage, IDeletePlanByAdminAppService delete)
		{
			_getPage = getPage;
			_delete = delete;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetPlanByAdminDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
			=> await _getPage.Run(pageNumber, pageSize, cancellationToken);

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
