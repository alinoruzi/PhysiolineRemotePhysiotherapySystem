using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Domain.Repositories
{
	public interface IPlanRepository : IBaseRepository<Plan>
	{
		Task<Plan> GetAsyncInclude(long id, CancellationToken cancellationToken);
	}
}
