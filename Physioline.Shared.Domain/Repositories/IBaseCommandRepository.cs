namespace Physioline.Shared.Domain.Repositories
{
	public interface IBaseCommandRepository<TKey, T> where T: class
	{
		Task Create(T entity, CancellationToken cancellationToken);
		Task Delete(TKey id, CancellationToken cancellationToken);
		Task Update(T entity, CancellationToken cancellationToken);
		Task Save(CancellationToken cancellationToken);
	}
}
