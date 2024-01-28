using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
    [Route("api/expert/exercise-category/")]
    [ApiController]
    public class ExerciseCategoryController : ControllerBase
    {
        private readonly IGetExerciseCategoryAppService _get;
        private readonly ISearchExerciseCategoryAppService _search;


        public ExerciseCategoryController(IGetExerciseCategoryAppService get, ISearchExerciseCategoryAppService search)
        {
            _get = get;
            _search = search;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseCategoryDto>> Get(long id,
            CancellationToken cancellationToken)
        {
            var result = await _get.Run(id, cancellationToken);
            return !result ? StatusCode(result, result.Message) : Ok(result.Value);
        }

        [HttpGet("Search")]
        public async Task<List<ExerciseCategorySearchResultDto>> Search(
            [FromQuery] ExerciseCategorySearchInputDto dto,
            CancellationToken cancellationToken)
            => await _search.Run(dto,cancellationToken);
        
    }
}
