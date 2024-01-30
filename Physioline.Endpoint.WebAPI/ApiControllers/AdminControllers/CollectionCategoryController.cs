using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Route("api/admin/collection-category/")]
	[ApiController]
	public class CollectionCategoryController : ControllerBase
	{
		private readonly IAddCollectionCategoryByAdminAppService _add;
		private readonly IDeleteCollectionCategoryByAdminAppService _delete;
		private readonly IEditCollectionCategoryByAdminAppService _edit;
		private readonly IGetCollectionCategoryAppService _get;
		private readonly IGetCollectionCategoriesPageListByAdminAppService _getPage;
		private readonly ISearchCollectionCategoryAppService _search;

		public CollectionCategoryController(
			IGetCollectionCategoriesPageListByAdminAppService getPage,
			IGetCollectionCategoryAppService get,
			ISearchCollectionCategoryAppService search,
			IAddCollectionCategoryByAdminAppService add,
			IEditCollectionCategoryByAdminAppService edit,
			IDeleteCollectionCategoryByAdminAppService delete)
		{
			_getPage = getPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetCollectionCategoryListItemDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
			=> await _getPage.Run(pageNumber, pageSize, cancellationToken);

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

		[HttpPost]
		public async Task<ActionResult> Add(AddCollectionCategoryDto dto, CancellationToken cancellationToken)
		{
			long userId = 1;
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditCollectionCategoryDto dto, CancellationToken cancellationToken)
		{
			var result = await _edit.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
