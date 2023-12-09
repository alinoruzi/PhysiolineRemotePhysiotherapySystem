using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.CommandRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.CommandRepositories
{
	public class CategoryCommandRepository : ICategoryCommandRepository
	{
		private readonly EmContext _context;
		public CategoryCommandRepository(EmContext context)
		{
			_context = context;
		}

		public async Task Create(Category entity, CancellationToken cancellationToken)
			=> await _context.Categories.AddAsync(entity,cancellationToken);
		
		public async Task AddRange(IEnumerable<Category> entities, CancellationToken cancellationToken)
			=> await _context.Categories.AddRangeAsync(entities,cancellationToken);
		
		public async Task Save(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
