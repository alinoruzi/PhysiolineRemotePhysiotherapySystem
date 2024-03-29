using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Authorize(Roles = "Client")]
	[Route("api/client/[controller]")]
	[ApiController]
	public class CollectionController : ControllerBase
	{
		private readonly IGetCollectionByClientAppService _get;
		public CollectionController(IGetCollectionByClientAppService get)
		{
			_get = get;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetCollectionByClientDto>> Get(long id,
			CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}
	}
}
