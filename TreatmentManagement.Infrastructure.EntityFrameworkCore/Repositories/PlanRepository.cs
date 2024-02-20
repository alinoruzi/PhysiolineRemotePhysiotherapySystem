using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class PlanRepository : BaseRepository<Plan>, IPlanRepository
	{
		private readonly TmContext _context;
		public PlanRepository(TmContext context) : base(context)
		{
			_context = context;
		}
		public async Task<Plan> GetAsyncInclude(long id, CancellationToken cancellationToken)
		{
			return await _context.Plans.Include(p => p.Details)
				.ThenInclude(pd => pd.Collection)
				.ThenInclude(c => c.Details)
				.ThenInclude(cd => cd.Collection)
				.FirstAsync(p => p.Id == id,cancellationToken);
		}
	}
}
