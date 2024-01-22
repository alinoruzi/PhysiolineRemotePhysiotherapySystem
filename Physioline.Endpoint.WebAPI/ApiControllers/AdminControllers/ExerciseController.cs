using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
    [Route("api/admin/[controller]/")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IGetAllExercisesByAdminAppService _getAll;
        private readonly IGetExerciseByAdminAppService _get;
        private readonly ISearchExerciseAppService _search;
        private readonly IAddExerciseByAdminAppService _add;
        private readonly IEditExerciseByAdminAppService _edit;
        private readonly IDeleteExerciseByAdminAppService _delete;

        public ExerciseController(IAddExerciseByAdminAppService addExercise, 
            IGetAllExercisesByAdminAppService getAll, 
            IGetExerciseByAdminAppService get, 
            IEditExerciseByAdminAppService edit, ISearchExerciseAppService search, IDeleteExerciseByAdminAppService delete)
        {
            _add = addExercise;
            _getAll = getAll;
            _get = get;
            _edit = edit;
            _search = search;
            _delete = delete;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetExerciseListItemByAdminDto>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10 )
            => await _getAll.Run(pageNumber, pageSize, cancellationToken);
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseByAdminDto>> Get(long id, CancellationToken cancellationToken)
        {
            var result = await _get.Run(id, cancellationToken);
            return !result ? StatusCode(result, result.Message) : Ok(result.Value);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<SearchResultExerciseDto>>> Search([FromQuery] SearchInputExerciseDto dto, CancellationToken cancellationToken)
            => await _search.Run(dto,cancellationToken);

        [HttpPost]
        public async Task<ActionResult> Add(AddExerciseDto dto,CancellationToken cancellationToken)
        {
            long userId = 1;
            var result = await _add.Run(dto,userId, cancellationToken); 
            return StatusCode(result,result.Message);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(EditExerciseDto dto, CancellationToken cancellationToken)
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