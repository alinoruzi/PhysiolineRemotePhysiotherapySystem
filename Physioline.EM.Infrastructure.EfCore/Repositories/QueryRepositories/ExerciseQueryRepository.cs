using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.QueryRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.QueryRepositories
{
	public class ExerciseQueryRepository : IExerciseQueryRepository
	{
		private readonly EmContext _context;
		public ExerciseQueryRepository(EmContext context)
		{
			_context = context;
		}

		public async Task<List<Exercise>> PartialGet(int countPerPage, int pageNumber, CancellationToken cancellationToken)
			=> await _context.Exercises
				.Skip(--pageNumber * countPerPage)
				.Take(countPerPage)
				.OrderByDescending(e=>e.CreatedAt)
				.Include(e=>e.ExerciseCategories)
				.Include(e=>e.Guides)
				.Include(e=>e.Picture)
				.Include(e=>e.Video)
				.AsNoTracking()
				.ToListAsync(cancellationToken);

		public async Task<List<Exercise>> SearchByTitle(string title, CancellationToken cancellationToken)
			=> await _context.Exercises
				.Where(e => e.Title.Contains(title))
				.Include(e=>e.ExerciseCategories)
				.Include(e=>e.Guides)
				.Include(e=>e.Picture)
				.Include(e=>e.Video)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task<Exercise?> Get(long id, CancellationToken cancellationToken)
			=> await _context.Exercises.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);
		
		public async Task<List<Exercise>> GetAll(CancellationToken cancellationToken)
			=> await _context.Exercises
				.Include(e=>e.ExerciseCategories)
				.Include(e=>e.Guides)
				.Include(e=>e.Picture)
				.Include(e=>e.Video)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
	}
}
