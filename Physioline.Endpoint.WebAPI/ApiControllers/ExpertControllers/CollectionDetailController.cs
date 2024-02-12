using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert")]
	[Route("api/expert/collection-detail/")]
	[ApiController]
	public class CollectionDetailController : ControllerBase
	{
		private readonly IAddCollectionDetailByExpertAppService _add;
		private readonly IDeleteCollectionDetailByExpertAppService _delete;
		private readonly IEditCollectionDetailByExpertAppService _edit;
		private readonly IGetCollectionDetailsByExpertAppService _get;

		public CollectionDetailController(IGetCollectionDetailsByExpertAppService get, IAddCollectionDetailByExpertAppService add,
			IEditCollectionDetailByExpertAppService edit, IDeleteCollectionDetailByExpertAppService delete)
		{
			_get = get;
			_add = add;
			_edit = edit;
			_delete = delete;
		}

		[HttpGet("{collectionId}")]
		public async Task<ActionResult<List<GetCollectionDetailItemDto>>> Get(long collectionId,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			return await _get.Run(collectionId, userId, cancellationToken);
		}

		[HttpPost]
		public async Task<ActionResult> Add(AddCollectionDetailDto dto,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditCollectionDetailDto dto,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _edit.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id,
			CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _delete.Run(id, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
