using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class CollectionRepository : BaseRepository<Collection>, ICollectionRepository
	{
		private readonly TmContext _context;
		public CollectionRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
