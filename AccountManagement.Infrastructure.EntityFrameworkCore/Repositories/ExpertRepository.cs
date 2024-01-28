using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class ExpertRepository : BaseRepository<Expert> , IExpertRepository
	{
		private readonly AmContext _context;
		public ExpertRepository(AmContext context) : base(context)
		{
			_context = context;
		}
	}
}
