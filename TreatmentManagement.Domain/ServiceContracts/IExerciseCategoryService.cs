using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Domain.ServiceContracts
{
	public interface IExerciseCategoryService
	{
		Task<ExerciseCategory> GetById(long id, CancellationToken cancellationToken);
		Task<IEnumerable<ExerciseCategory>> GetAll(CancellationToken cancellationToken);
		Task<bool> IsExistById(long id, CancellationToken cancellationToken);
		Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken);
		Task<long> Add(ExerciseCategory entity,CancellationToken cancellationToken);
		Task<int> CommitChanges(CancellationToken cancellationToken);

	}
}
