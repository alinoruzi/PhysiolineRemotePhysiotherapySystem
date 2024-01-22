using System.Linq.Expressions;

namespace Physioline.Framework.Domain
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity> GetAsync(long id, CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression,
			CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetPageAsync(int pageNumber,int pageSize ,CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> expression,
			int pageNumber,int pageSize ,CancellationToken cancellationToken);
		Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression,CancellationToken cancellationToken);
		Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
		void Update(TEntity entity);
	}
}
