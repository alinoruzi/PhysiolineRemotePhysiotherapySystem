using Microsoft.EntityFrameworkCore;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.Shared.Infrastructure.Repositories.QueryRepositories
{
	public class BaseQueryRepository<TKey,T> : IBaseQueryRepository<TKey,T> where T : class
	{
		private readonly DbContext _context;
		public BaseQueryRepository(DbContext context)
		{
			_context = context;
		}
		public async Task<T?> Get(TKey id, CancellationToken cancellationToken)
			=> await _context.FindAsync<T>(cancellationToken);
		
		public async Task<List<T>> GetAll(CancellationToken cancellationToken)
			=> await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
	}
}
