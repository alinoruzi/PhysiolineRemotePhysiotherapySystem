using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Domain.ServiceContracts
{
	public interface IExerciseCategoryService
	{
		public Task<ExerciseCategory> GetById(long id, CancellationToken cancellationToken);
		public Task<IEnumerable<ExerciseCategory>> GetAll(CancellationToken cancellationToken);
		public Task<bool> IsExistById(long id, CancellationToken cancellationToken);
		public Task<long> Add(ExerciseCategory exercise,CancellationToken cancellationToken);
	}
}
