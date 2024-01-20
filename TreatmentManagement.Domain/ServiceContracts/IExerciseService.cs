using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Domain.ServiceContracts
{
	public interface IExerciseService
	{
		public Task<Exercise> GetById(long id, CancellationToken cancellationToken);
		public Task<bool> IsExistById(long id, CancellationToken cancellationToken);
		public Task<long> Add(Exercise entity, CancellationToken cancellationToken);
		public Task<int> CommitChanges(CancellationToken cancellationToken);
	}
}
