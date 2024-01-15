using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Models;
using TreatmentManagement.Application.Contracts.AdminServices;
using TreatmentManagement.Application.Contracts.DTOs;
using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.Commands;
using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Controllers
{
    [Route("api/admin/[controller]/")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IAddGlobalExercise _addGlobalExercise;
        public ExerciseController(IAddGlobalExercise addGlobalExercise)
        {
            _addGlobalExercise = addGlobalExercise;
        }


        [HttpPost]
        public async Task<ExerciseOutputDto> GetCategories(ExerciseInputDto inputDto,CancellationToken cancellationToken)
        {
            return await _addGlobalExercise.Run(inputDto, cancellationToken);
        }
    }
}
