using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Route("api/admin/collection-detail/")]
	[ApiController]
	public class CollectionDetailController : ControllerBase
	{
		private readonly IAddCollectionDetailByAdminAppService _add;
		private readonly IDeleteCollectionDetailByAdminAppService _delete;
		private readonly IEditCollectionDetailByAdminAppService _edit;
		private readonly IGetCollectionDetailsByAdminAppService _get;

		public CollectionDetailController(IGetCollectionDetailsByAdminAppService get,
			IAddCollectionDetailByAdminAppService add,
			IEditCollectionDetailByAdminAppService edit,
			IDeleteCollectionDetailByAdminAppService delete)
		{
			_get = get;
			_add = add;
			_edit = edit;
			_delete = delete;
		}

		[HttpGet("{collectionId}")]
		public async Task<ActionResult<List<GetCollectionDetailItemDto>>> Get(long collectionId,
			CancellationToken cancellationToken)
			=> await _get.Run(collectionId, cancellationToken);

		[HttpPost]
		public async Task<ActionResult> Add(AddCollectionDetailDto dto,
			CancellationToken cancellationToken)
		{
			long userId = 1;
			var result = await _add.Run(dto, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpPut]
		public async Task<ActionResult> Edit(EditCollectionDetailDto dto,
			CancellationToken cancellationToken)
		{
			var result = await _edit.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id,
			CancellationToken cancellationToken)
		{
			var result = await _delete.Run(id, cancellationToken);
			return StatusCode(result, result.Message);
		}
	}
}
