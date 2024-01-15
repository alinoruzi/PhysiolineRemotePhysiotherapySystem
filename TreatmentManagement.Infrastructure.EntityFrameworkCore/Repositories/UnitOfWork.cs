using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseRepositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly TMContext _context;
		public UnitOfWork(TMContext context)
		{
			_context = context;
		}
		

		private IExerciseCategoryRepository _exerciseCategoryRepository;
		public IExerciseCategoryRepository ExerciseCategoryRepository
			=> _exerciseCategoryRepository = _exerciseCategoryRepository ?? new ExerciseCategoryRepository(_context);

		
		private IExerciseRepository _exerciseRepository;
		public IExerciseRepository ExerciseRepository
			=> _exerciseRepository = _exerciseRepository ?? new ExerciseRepository(_context);
		
		
		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);


		public void Dispose()
			=> _context.Dispose();

	}
}
