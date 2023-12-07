using Physioline.EM.Domain.Entities;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.EM.Domain.Repositories.QueryRepositories
{
	public interface IExerciseQueryRepository : IBaseQueryRepository<long, Exercise>
	{
		Task<IEnumerable<Exercise>> PartialGet(int countPerPage, int pageNumber, CancellationToken cancellationToken);
		Task<IEnumerable<Exercise>> SearchByTitle(string title, CancellationToken cancellationToken);
	}
}
