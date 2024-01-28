using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class AdminRepository : BaseRepository<Admin>,IAdminRepository
	{
		private readonly AmContext _context;
		public AdminRepository(AmContext context) : base(context)
		{
			_context = context;
		}
	}
}
