using Microsoft.EntityFrameworkCore;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.Shared.Infrastructure.Repositories.CommandRepositories
{
	public class BaseCommandRepository<TKey,T> : IBaseCommandRepository<TKey,T> where T : class
	{
		private readonly DbContext _context;
		public BaseCommandRepository(DbContext context)
		{
			_context = context;
		}
		public async Task Create(T entity, CancellationToken cancellationToken)
			=> await _context.AddAsync(entity, cancellationToken);

		public async Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken)
			=> await _context.AddRangeAsync(entities, cancellationToken);
		public async Task Save(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
