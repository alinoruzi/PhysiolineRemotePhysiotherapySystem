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


		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);


		public void Dispose()
			=> _context.Dispose();

	}
}
