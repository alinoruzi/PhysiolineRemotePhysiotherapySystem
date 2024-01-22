using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class CollectionCategoryRepository : BaseRepository<CollectionCategory> , ICollectionCategoryRepository
	{
		private readonly TmContext _context;
		
		public CollectionCategoryRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
