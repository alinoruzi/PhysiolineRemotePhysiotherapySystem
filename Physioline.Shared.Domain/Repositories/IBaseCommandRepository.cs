namespace Physioline.Shared.Domain.Repositories
{
	public interface IBaseCommandRepository<TKey, T> where T: class
	{
		Task Create(T entity, CancellationToken cancellationToken);
		Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken);
		Task Save(CancellationToken cancellationToken);
	}
}
