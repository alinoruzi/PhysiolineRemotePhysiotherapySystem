using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/[controller]")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private readonly IGetExerciseByClientAppService _get;
		public ExerciseController(IGetExerciseByClientAppService get)
		{
			_get = get;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetExerciseByClientDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}
	}
}
