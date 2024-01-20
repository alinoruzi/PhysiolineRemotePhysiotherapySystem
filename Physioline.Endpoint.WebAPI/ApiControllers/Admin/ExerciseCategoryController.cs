using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;

namespace Physioline.Endpoint.WebAPI.ApiControllers.Admin
{
    [Route("api/admin/exercise-category/")]
    [ApiController]
    public class ExerciseCategoryController : ControllerBase
    {
        private readonly IAddExerciseCategoryAppService _addExerciseCategory;
        private readonly IGetExerciseCategoryAppService _getExerciseCategory;
        private readonly IGetAllExerciseCategoriesAppService _getAllExerciseCategories;
        private readonly IEditExerciseCategoryAppService _editExerciseCategory;
        private readonly IDeleteExerciseCategoryAppService _deleteExerciseCategory;
        public ExerciseCategoryController(IAddExerciseCategoryAppService addExercise, IGetExerciseCategoryAppService getExerciseCategory, IGetAllExerciseCategoriesAppService getAllExerciseCategories, IEditExerciseCategoryAppService editExerciseCategory, IDeleteExerciseCategoryAppService deleteExerciseCategory)
        {
            _addExerciseCategory = addExercise;
            _getExerciseCategory = getExerciseCategory;
            _getAllExerciseCategories = getAllExerciseCategories;
            _editExerciseCategory = editExerciseCategory;
            _deleteExerciseCategory = deleteExerciseCategory;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseCategoryListItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _getAllExerciseCategories.Run(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseCategoryDto>> Get(long id, CancellationToken cancellationToken)
        {
            var result = await _getExerciseCategory.Run(id, cancellationToken);
            if (!result)
                return StatusCode(result, result.Message);

            return result.Value;
        }
         
        [HttpPost]
        public async Task<ActionResult> Add(AddExerciseCategoryDto dto,CancellationToken cancellationToken)
        {
            var result = await _addExerciseCategory.Run(dto, cancellationToken);
            return StatusCode(result,result.Message);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(EditExerciseCategoryDto dto, CancellationToken cancellationToken)
        {
            var result = await _editExerciseCategory.Run(dto, cancellationToken);
            return StatusCode(result,result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var result = await _deleteExerciseCategory.Run(id, cancellationToken);
            return StatusCode(result,result.Message);
        }
    }
}
