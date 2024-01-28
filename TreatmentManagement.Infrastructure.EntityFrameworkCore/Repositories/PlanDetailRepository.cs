using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class PlanDetailRepository : BaseRepository<PlanDetail>, IPlanDetailRepository
	{
		private readonly TmContext _context;
		public PlanDetailRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
