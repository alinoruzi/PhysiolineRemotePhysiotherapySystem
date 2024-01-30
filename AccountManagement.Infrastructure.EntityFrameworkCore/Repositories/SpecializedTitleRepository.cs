using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class SpecializedTitleRepository : BaseRepository<SpecializedTitle>, ISpecializedTitleRepository
	{
		private readonly AmContext _context;
		public SpecializedTitleRepository(AmContext context) : base(context)
		{
			_context = context;
		}
	}
}
