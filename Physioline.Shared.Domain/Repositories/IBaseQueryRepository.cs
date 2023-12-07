namespace Physioline.Shared.Domain.Repositories
{
	public interface IBaseQueryRepository<TKey, T> where T : class
	{
		Task<T> Get(TKey id, CancellationToken cancellationToken);
		Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
	}
}
