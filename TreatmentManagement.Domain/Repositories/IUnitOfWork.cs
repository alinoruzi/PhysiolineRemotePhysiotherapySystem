namespace TreatmentManagement.Domain.Repositories
{
	public interface IUnitOfWork
	{
		public IExerciseCategoryRepository ExerciseCategoryRepository { get; }
		public IExerciseRepository ExerciseRepository { get; }
		public ICollectionCategoryRepository CollectionCategoryRepository { get; }
		
		Task<int> CommitAsync(CancellationToken cancellationToken);
		void Dispose();
	}
}
