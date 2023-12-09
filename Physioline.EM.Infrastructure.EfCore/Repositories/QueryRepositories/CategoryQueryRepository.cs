using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.QueryRepositories;
using Physioline.Shared.Infrastructure.Repositories.QueryRepositories;
using System.Xml.Schema;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.QueryRepositories
{
	public class CategoryQueryRepository : BaseQueryRepository<long,Category>, ICategoryQueryRepository
	{
		private readonly EmContext _context;
		
		public CategoryQueryRepository(EmContext context) : base(context)
		{
			_context = context;
		}
		public async Task<List<Category>> SearchByTitle(string title, CancellationToken cancellationToken)
			=> await _context.Categories
				.Where(c => c.Title.Contains(title))
				.AsNoTracking().ToListAsync(cancellationToken);

	}
}
