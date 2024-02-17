using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly AmContext _context;
		public UserRepository(AmContext context) : base(context)
		{
			_context = context;
		}
		public async Task<IEnumerable<User>> GetPageIncludePersonAsync(UserRole role, 
			int pageNumber, int pageSize, CancellationToken cancellationToken)
		{
			return await _context.Users.Include(u=>u.Person)
				.AsNoTracking().Where(u=>u.UserRole == role && u.IsRegistered)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize).ToListAsync(cancellationToken);
		}
		public async Task<User> GetAsyncIncludePerson(long id, CancellationToken cancellationToken)
		{
			return await _context.Users.Include(u => u.Person)
				.FirstAsync(u => u.Id == id, cancellationToken);

		}
	}
}
