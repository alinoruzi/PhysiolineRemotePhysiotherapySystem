using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/[controller]")]
	public class CollectionFeedbackController : ControllerBase
	{
		private readonly IAddCollectionFeedbackByClientAppService _add;
		public CollectionFeedbackController(IAddCollectionFeedbackByClientAppService add)
		{
			_add = add;
		}
	
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddCollectionFeedbackDto dto, 
			CancellationToken cancellationToken)
		{
			long userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
