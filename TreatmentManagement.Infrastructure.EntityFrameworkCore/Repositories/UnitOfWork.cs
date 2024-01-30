using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly TmContext _context;


		private ICollectionCategoryRepository _collectionCategoryRepository;


		private ICollectionDetailRepository _collectionDetailRepository;


		private ICollectionRepository _collectionRepository;


		private IExerciseCategoryRepository _exerciseCategoryRepository;


		private IExerciseRepository _exerciseRepository;


		private IPlanDetailRepository _planDetailRepository;


		private IPlanRepository _planRepository;
		public UnitOfWork(TmContext context)
		{
			_context = context;
		}

		public IExerciseCategoryRepository ExerciseCategoryRepository
			=> _exerciseCategoryRepository = _exerciseCategoryRepository ?? new ExerciseCategoryRepository(_context);

		public IExerciseRepository ExerciseRepository
			=> _exerciseRepository = _exerciseRepository ?? new ExerciseRepository(_context);

		public ICollectionCategoryRepository CollectionCategoryRepository
			=> _collectionCategoryRepository = _collectionCategoryRepository ?? new CollectionCategoryRepository(_context);

		public ICollectionRepository CollectionRepository
			=> _collectionRepository = _collectionRepository ?? new CollectionRepository(_context);

		public ICollectionDetailRepository CollectionDetailRepository
			=> _collectionDetailRepository = _collectionDetailRepository ?? new CollectionDetailRepository(_context);

		public IPlanRepository PlanRepository
			=> _planRepository = _planRepository ?? new PlanRepository(_context);

		public IPlanDetailRepository PlanDetailRepository
			=> _planDetailRepository = _planDetailRepository ?? new PlanDetailRepository(_context);


		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);


		public void Dispose()
			=> _context.Dispose();
	}
}
