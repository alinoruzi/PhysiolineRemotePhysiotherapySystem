using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/[controller]")]
	public class ExerciseFeedbackController : ControllerBase
	{
		private readonly IAddExerciseFeedbackByClientAppService _add;
		public ExerciseFeedbackController(IAddExerciseFeedbackByClientAppService add)
		{
			_add = add;
		}
	
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddExerciseFeedbackDto dto, 
			CancellationToken cancellationToken)
		{
			long userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
