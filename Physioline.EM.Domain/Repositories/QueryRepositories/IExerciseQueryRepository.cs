using Physioline.EM.Domain.Entities;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.EM.Domain.Repositories.QueryRepositories
{
	public interface IExerciseQueryRepository : IBaseQueryRepository<long, Exercise>
	{
		Task<List<Exercise>> PartialGet(int countPerPage, int pageNumber, CancellationToken cancellationToken);
		Task<List<Exercise>> SearchByTitle(string title, CancellationToken cancellationToken);
	}
}
