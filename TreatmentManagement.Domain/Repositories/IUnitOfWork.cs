using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;

namespace TreatmentManagement.Domain.Repositories
{
	public interface IUnitOfWork
	{
		public IExerciseCategoryRepository ExerciseCategoryRepository { get; }
		public IExerciseRepository ExerciseRepository { get; }

		Task<int> CommitAsync(CancellationToken cancellationToken);
		void Dispose();
	}
}
