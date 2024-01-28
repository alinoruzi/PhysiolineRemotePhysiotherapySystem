using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UserRepository : BaseRepository<User>,IUserRepository
	{
		private readonly AmContext _context;
		public UserRepository(AmContext context) : base(context)
		{
			_context = context;
		}
	}
}
