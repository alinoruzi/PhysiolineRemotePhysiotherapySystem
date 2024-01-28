using System.Runtime.InteropServices;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly TmContext _context;
		public UnitOfWork(TmContext context)
		{
			_context = context;
		}
		

		private IExerciseCategoryRepository _exerciseCategoryRepository;
		public IExerciseCategoryRepository ExerciseCategoryRepository
			=> _exerciseCategoryRepository = _exerciseCategoryRepository ?? new ExerciseCategoryRepository(_context);

		
		private IExerciseRepository _exerciseRepository;
		public IExerciseRepository ExerciseRepository
			=> _exerciseRepository = _exerciseRepository ?? new ExerciseRepository(_context);

		
		private ICollectionCategoryRepository _collectionCategoryRepository;
		public ICollectionCategoryRepository CollectionCategoryRepository
			=> _collectionCategoryRepository = _collectionCategoryRepository ?? new CollectionCategoryRepository(_context);

		
		private ICollectionRepository _collectionRepository;
		public ICollectionRepository CollectionRepository
			=> _collectionRepository = _collectionRepository ?? new CollectionRepository(_context);

		
		private ICollectionDetailRepository _collectionDetailRepository;
		public ICollectionDetailRepository CollectionDetailRepository
			=> _collectionDetailRepository = _collectionDetailRepository ?? new CollectionDetailRepository(_context);


		private IPlanRepository _planRepository;
		public IPlanRepository PlanRepository
			=> _planRepository = _planRepository ?? new PlanRepository(_context);

		
		private IPlanDetailRepository _planDetailRepository;
		public IPlanDetailRepository PlanDetailRepository
			=> _planDetailRepository = _planDetailRepository ?? new PlanDetailRepository(_context);
		

		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);


		public void Dispose()
			=> _context.Dispose();

	}
}
