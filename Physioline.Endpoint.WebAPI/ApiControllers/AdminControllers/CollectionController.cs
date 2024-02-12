using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/admin/[controller]")]
	[ApiController]
	public class CollectionController : ControllerBase
	{
		private readonly IAddCollectionByAdminAppService _add;
		private readonly IDeleteCollectionByAdminAppService _delete;
		private readonly IEditCollectionByAdminAppService _edit;
		private readonly IGetCollectionByAdminAppService _get;
		private readonly IGetCollectionsPageListByAdminAppService _getPage;
		private readonly ISearchCollectionByAdminAppService _search;

		public CollectionController(IGetCollectionsPageListByAdminAppService getPage,
			IGetCollectionByAdminAppService get,
			ISearchCollectionByAdminAppService search,
			IAddCollectionByAdminAppService add,
			IEditCollectionByAdminAppService edit,
			IDeleteCollectionByAdminAppService delete)
		{
			_getPage = getPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetCollectionListItemByAdminDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
			=> await _getPage.Run(pageNumber, pageSize, cancellationToken);

		[HttpGet("{id}")]
		public async Task<ActionResult<GetCollectionByAdminDto>> Get(long id, CancellationToken cancellationToken)
		{
			var result = await _get.Run(id, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<ActionResult<List<SearchCollectionOutputDto>>> Search
		([FromQuery] SearchCollectionInputDto dto,
			CancellationToken cancellationToken)
			=> await _search.Run(dto, cancellationToken);

		[HttpPost]
		public async Task<ActionResult> Add(AddCollectionDto dto, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditCollectionDto dto, CancellationToken cancellationToken)
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
