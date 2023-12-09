using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.QueryRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.QueryRepositories
{
	public class CategoryQueryRepository : ICategoryQueryRepository
	{
		private readonly EmContext _context;
		
		public CategoryQueryRepository(EmContext context)
		{
			_context = context;
		}
		public async Task<List<Category>> SearchByTitle(string title, CancellationToken cancellationToken)
			=> await _context.Categories
				.Where(c => c.Title.Contains(title))
				.Include(c=>c.Children)
				.AsNoTracking().ToListAsync(cancellationToken);

		public async Task<Category?> Get(long id, CancellationToken cancellationToken)
			=> await _context.Categories.Where(x=>x.Id==id).FirstOrDefaultAsync(cancellationToken);

		public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
			=> await _context.Categories
				.Include(c=>c.Children)
				.AsNoTracking().ToListAsync(cancellationToken);
	}
}
