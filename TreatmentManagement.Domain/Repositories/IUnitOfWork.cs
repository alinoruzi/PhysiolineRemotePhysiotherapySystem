namespace TreatmentManagement.Domain.Repositories
{
	public interface IUnitOfWork
	{
		public IExerciseCategoryRepository ExerciseCategoryRepository { get; }
		public IExerciseRepository ExerciseRepository { get; }
		public ICollectionCategoryRepository CollectionCategoryRepository { get; }
		public ICollectionRepository CollectionRepository { get; }
		public ICollectionDetailRepository CollectionDetailRepository { get; }
		
		Task<int> CommitAsync(CancellationToken cancellationToken);
		void Dispose();
	}
}
