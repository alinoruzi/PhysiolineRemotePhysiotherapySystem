using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.Controllers
{
    [Route("api/admin/[controller]/")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IAddExerciseAppService _addExercise;
        private readonly IGetExerciseByAdminAppService _getExerciseByAdmin;
        public ExerciseController(IAddExerciseAppService addExerciseAppService, IGetExerciseByAdminAppService getExerciseByAdmin)
        {
            _addExercise = addExerciseAppService;
            _getExerciseByAdmin = getExerciseByAdmin;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseByAdminDto>> Get(long id, CancellationToken cancellationToken)
        {
            var result = await _getExerciseByAdmin.Run(id,cancellationToken);
            if (!result)
                return StatusCode(result, result.Message);
            
            return result.Value;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddExerciseDto dto,CancellationToken cancellationToken)
        {
            var result = await _addExercise.Run(dto, cancellationToken);
            return StatusCode(result,result.Message);
        }
    }
}
