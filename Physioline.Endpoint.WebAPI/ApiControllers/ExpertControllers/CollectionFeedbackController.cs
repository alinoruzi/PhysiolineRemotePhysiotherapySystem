using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert")]
	[Route("api/expert/[controller]/[action]")]
	public class CollectionFeedbackController : ControllerBase
	{
		private readonly IGetSuccessCollectionFeedbackListByExpertAppService _getSuccess;
		private readonly IGetUnsuccessfulCollectionFeedbackListByExpertAppService _getUnsuccessful;


		public CollectionFeedbackController(IGetSuccessCollectionFeedbackListByExpertAppService getSuccess, 
			IGetUnsuccessfulCollectionFeedbackListByExpertAppService getUnsuccessful)
		{
			_getSuccess = getSuccess;
			_getUnsuccessful = getUnsuccessful;
		}
		
		
		[HttpGet]
		public async Task<ActionResult<List<GetCollectionFeedbackListItemDto>>> GetSuccessfulList( [FromQuery] long planId, 
			CancellationToken cancellationToken)
		{
			return Ok(await _getSuccess.Run(planId, cancellationToken));
		}
		
		
		[HttpGet]
		public async Task<ActionResult<List<GetCollectionFeedbackListItemDto>>> GetUnsuccessfulList( [FromQuery] long planId, 
			CancellationToken cancellationToken)
		{
			return Ok(await _getUnsuccessful.Run(planId, cancellationToken));
		}
	}
}
