using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.QueryRepositories;
using Physioline.Shared.Infrastructure.Repositories.QueryRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.QueryRepositories
{
	public class ExerciseQueryRepository : BaseQueryRepository<long,Exercise>, IExerciseQueryRepository
	{
		private readonly EmContext _context;
		public ExerciseQueryRepository(EmContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Exercise>> PartialGet(int countPerPage, int pageNumber, CancellationToken cancellationToken)
			=> await _context.Exercises
				.Skip(--pageNumber * countPerPage)
				.Take(countPerPage)
				.OrderByDescending(e=>e.CreatedAt)
				.ToListAsync(cancellationToken);

		public async Task<IEnumerable<Exercise>> SearchByTitle(string title, CancellationToken cancellationToken)
			=> await _context.Exercises
				.Where(e => e.Title.Contains(title))
				.ToListAsync(cancellationToken);
	}
}
