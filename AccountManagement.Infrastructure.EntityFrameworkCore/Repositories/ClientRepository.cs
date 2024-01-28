using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class ClientRepository : BaseRepository<Client>, IClientRepository
	{
		private readonly AmContext _context;
		public ClientRepository(AmContext context) : base(context)
		{
			_context = context;
		}
	}
}
