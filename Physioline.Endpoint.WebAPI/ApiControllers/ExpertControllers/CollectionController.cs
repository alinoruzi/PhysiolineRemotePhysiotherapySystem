using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Route("api/expert/[controller]")]
	[ApiController]
	public class CollectionController : ControllerBase
	{
		private readonly IGetGlobalCollectionsPageListByExpertAppService _getGlobalPage;
		private readonly IGetSpecificCollectionsPageListByExpertAppService _getSpecificPage;
		private readonly IGetCollectionByExpertAppService _get;
		private readonly ISearchCollectionByExpertAppService _search;
		private readonly IAddCollectionByExpertAppService _add;
		private readonly IEditCollectionByExpertAppService _edit;
		private readonly IDeleteCollectionByExpertAppService _delete;


		public CollectionController(IGetGlobalCollectionsPageListByExpertAppService getGlobalPage,
			IGetSpecificCollectionsPageListByExpertAppService getSpecificPage,
			IGetCollectionByExpertAppService get,
			ISearchCollectionByExpertAppService search,
			IAddCollectionByExpertAppService add,
			IEditCollectionByExpertAppService edit,
			IDeleteCollectionByExpertAppService delete)
		{
			_getGlobalPage = getGlobalPage;
			_getSpecificPage = getSpecificPage;
			_get = get;
			_search = search;
			_add = add;
			_edit = edit;
			_delete = delete;
		}
		
		[HttpGet]
		public async Task<ActionResult<List<GetCollectionListItemByExpertDto>>> GetAll(CancellationToken cancellationToken,
			[FromQuery] bool global = false,
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10 )
		{
			long userId = 2;
			if (global)
				return await _getGlobalPage.Run(pageNumber, pageSize, cancellationToken);
			return await _getSpecificPage.Run(pageNumber, pageSize,userId, cancellationToken);
		} 

		[HttpGet("{id}")]
		public async Task<ActionResult<GetCollectionByExpertDto>> Get(long id, CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _get.Run(id, userId, cancellationToken);
			return !result ? StatusCode(result, result.Message) : Ok(result.Value);
		}

		[HttpGet("Search")]
		public async Task<ActionResult<List<SearchCollectionOutputDto>>> Search
		([FromQuery] SearchCollectionInputDto dto,
			CancellationToken cancellationToken)
		{
			long userId = 2;
			return await _search.Run(dto,userId,cancellationToken);
		} 
		
		[HttpPost]
		public async Task<ActionResult> Add(AddCollectionDto dto,CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _add.Run(dto, userId, cancellationToken); 
			return StatusCode(result,result.Message);
		}
		
		[HttpPut]
		public async Task<ActionResult> Edit(EditCollectionDto dto, CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _edit.Run(dto,userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
		{
			long userId = 2;
			var result = await _delete.Run(id,userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
	}
}
