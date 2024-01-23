using Microsoft.AspNetCore.Mvc;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertController
{
    [Route("api/expert/[controller]/")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IGetSpecificExercisesByExpertAppService _getAllSpecific;
        private readonly IGetGlobalExercisesByExpertAppService _getAllGlobal;
        private readonly IGetExerciseByExpertAppService _get;
        private readonly ISearchExerciseAppService _search;
        private readonly IAddExerciseByExpertAppService _add;
        private readonly IEditExerciseByExpertAppService _edit;
        private readonly IDeleteExerciseByExpertAppService _delete;

        public ExerciseController(IGetSpecificExercisesByExpertAppService getAllSpecific, IGetGlobalExercisesByExpertAppService getAllGlobal, IGetExerciseByExpertAppService get, ISearchExerciseAppService search, IAddExerciseByExpertAppService add, IEditExerciseByExpertAppService edit, IDeleteExerciseByExpertAppService delete)
        {
            _getAllSpecific = getAllSpecific;
            _getAllGlobal = getAllGlobal;
            _get = get;
            _search = search;
            _add = add;
            _edit = edit;
            _delete = delete;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetExerciseListItemByExpertDto>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] bool global = false,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10 )
        {
            long userId = 2;
            
             if (global)
                 return await _getAllGlobal.Run(pageNumber, pageSize, cancellationToken);
            
            return await _getAllSpecific.Run(pageNumber, pageSize,
                userId, cancellationToken);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseByExpertDto>> Get(long id, CancellationToken cancellationToken)
        {
            long userId = 2;
            var result = await _get.Run(id, userId,cancellationToken);
            return !result ? StatusCode(result, result.Message) : Ok(result.Value);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<SearchResultExerciseDto>>> Search([FromQuery] SearchInputExerciseDto dto, CancellationToken cancellationToken)
        {
            return BadRequest(await _search.Run(dto,cancellationToken));
        } 

        [HttpPost]
        public async Task<ActionResult> Add(AddExerciseDto dto,CancellationToken cancellationToken)
        {
            long userId = 2;
            var result = await _add.Run(dto,userId, cancellationToken); 
            return StatusCode(result,result.Message);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(EditExerciseDto dto, CancellationToken cancellationToken)
        {
            long userId = 2;
            var result = await _edit.Run(dto, userId, cancellationToken);
            return StatusCode(result, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            long userId = 2;
            var result = await _delete.Run(id, userId, cancellationToken);
            return StatusCode(result, result.Message);
        }
    }
}
