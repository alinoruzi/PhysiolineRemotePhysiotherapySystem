using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Domain;
using System.Linq.Expressions;

namespace Physioline.Framework.Infrastructure
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly DbContext _context;
		private readonly DbSet<TEntity> _dbSet;
		protected BaseRepository(DbContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public async Task<TEntity> GetAsync(long id, CancellationToken cancellationToken)
			=> await _dbSet.FindAsync(id) ?? throw new InvalidOperationException();

		public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
			=> await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
		
		public async Task<IEnumerable<TEntity>> GetPageAsync(int pageNumber, int pageSize,
			CancellationToken cancellationToken)
			=> await _dbSet.AsNoTracking().Skip((pageNumber-1)*pageSize)
				.Take(pageSize).ToListAsync(cancellationToken);
		
		public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression, 
			CancellationToken cancellationToken)
			=> await _dbSet.AnyAsync(expression,cancellationToken);
		
		public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression, 
			CancellationToken cancellationToken)
			=> await _dbSet.AsNoTracking().Where(expression).ToListAsync(cancellationToken);
		
		public async Task<TEntity> CreateAsync(TEntity entity, 
			CancellationToken cancellationToken)
		{
			await _dbSet.AddAsync(entity, cancellationToken);
			await SaveChangesAsync(cancellationToken);
			return entity;
		}

		public async Task SaveChangesAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
