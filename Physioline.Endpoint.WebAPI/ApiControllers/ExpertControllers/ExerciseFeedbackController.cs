using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert")]
	[Route("api/expert/[controller]/[action]")]
	public class ExerciseFeedbackController : ControllerBase
	{
		private readonly IGetSuccessExerciseFeedbackListByExpertAppService _getSuccess;
		private readonly IGetUnsuccessfulExerciseFeedbackListByExpertAppService _getUnsuccessful;


		public ExerciseFeedbackController(IGetSuccessExerciseFeedbackListByExpertAppService getSuccess,
			IGetUnsuccessfulExerciseFeedbackListByExpertAppService getUnsuccessful)
		{
			_getSuccess = getSuccess;
			_getUnsuccessful = getUnsuccessful;
		}
		
		[HttpGet]
		public async Task<ActionResult<List<GetExerciseFeedbackListItemDto>>> GetSuccessfulList( [FromQuery] long planId, 
			CancellationToken cancellationToken)
		{
			return Ok(await _getSuccess.Run(planId, cancellationToken));
		}
		
		
		[HttpGet]
		public async Task<ActionResult<List<GetExerciseFeedbackListItemDto>>> GetUnsuccessfulList( [FromQuery] long planId, 
			CancellationToken cancellationToken)
		{
			return Ok(await _getUnsuccessful.Run(planId, cancellationToken));
		}
	}
}
