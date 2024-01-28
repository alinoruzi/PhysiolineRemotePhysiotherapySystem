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
	}
}
