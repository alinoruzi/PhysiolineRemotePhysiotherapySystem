using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class CollectionFeedbackRepository : BaseRepository<CollectionFeedback>, ICollectionFeedbackRepository
	{
		private readonly TmContext _context;

		public CollectionFeedbackRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
