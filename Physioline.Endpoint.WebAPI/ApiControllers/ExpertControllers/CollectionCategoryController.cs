using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Route("api/expert/collection-category/")]
	[ApiController]
	public class CollectionCategoryController : ControllerBase
	{
		private readonly IGetCollectionCategoryAppService _get;
		private readonly ISearchCollectionCategoryAppService _search;
		public CollectionCategoryController(IGetCollectionCategoryAppService get,
			ISearchCollectionCategoryAppService search)
		{
			_get = get;
			_search = search;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetCollectionCategoryDto>> Get(long id, CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<ActionResult<List<CollectionCategorySearchResultDto>>> Search
		([FromQuery] CollectionCategorySearchInputDto dto,
			CancellationToken cancellationToken)
			=> await _search.Run(dto, cancellationToken);
	}
}
