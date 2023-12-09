using Physioline.EM.Domain.Entities;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.EM.Domain.Repositories.QueryRepositories
{
	public interface ICategoryQueryRepository : IBaseQueryRepository<long,Category>
	{
		Task<List<Category>> SearchByTitle(string title, CancellationToken cancellationToken);
	}
}
