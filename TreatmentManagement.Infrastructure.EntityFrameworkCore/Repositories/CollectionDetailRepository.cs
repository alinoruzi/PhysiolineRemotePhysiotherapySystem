using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class CollectionDetailRepository : BaseRepository<CollectionDetail>, ICollectionDetailRepository
	{
		private readonly TmContext _context;
		public CollectionDetailRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
