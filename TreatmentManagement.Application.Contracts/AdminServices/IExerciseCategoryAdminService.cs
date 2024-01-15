using Physioline.Framework.Application;
using TreatmentManagement.Application.Contracts.DTOs;

namespace TreatmentManagement.Application.Contracts.AdminServices
{
	public interface IExerciseCategoryAdminService
	{
		//Query Services:
		Task<OutputExerciseCategoryAdminDto> GetById(long id, CancellationToken cancellationToken);
		Task<List<OutputExerciseCategoryAdminDto>> GetAll(CancellationToken cancellationToken);
		Task<List<OutputExerciseCategoryAdminDto>> GetAllParents(CancellationToken cancellationToken);
		Task<List<OutputExerciseCategoryAdminDto>> GetChildrenById(long id, CancellationToken cancellationToken);
		Task<List<OutputExerciseCategoryAdminDto>> GetAllDeleted(CancellationToken cancellationToken);

		//Command Services:
		Task<OperationResult> Add(InputExerciseCategoryAdminDto exerciseCategoryAdminDto, CancellationToken cancellationToken);
		Task<OperationResult> Edit(long id, InputExerciseCategoryAdminDto exerciseCategoryAdminDto, CancellationToken cancellationToken);
		Task<OperationResult> Delete(long id, CancellationToken cancellationToken);
		Task<OperationResult> Restore(long id, CancellationToken cancellationToken);
	}
}
