using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ClientControllers
{
	[Route("api/client/collection-detail")]
	[ApiController]
	public class CollectionDetailController : ControllerBase
	{
		private readonly IGetCollectionDetailsByClientAppService _getAll;
		public CollectionDetailController(IGetCollectionDetailsByClientAppService getAll)
		{
			_getAll = getAll;
		}

		[HttpGet("{collectionId}")]
		public async Task<ActionResult<List<GetCollectionDetailItemDto>>> GetAll(long collectionId,
			CancellationToken cancellationToken)
			=> await _getAll.Run(collectionId, cancellationToken);
	}
}
