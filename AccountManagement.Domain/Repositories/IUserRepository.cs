using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using Physioline.Framework.Domain;

namespace AccountManagement.Domain.Repositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<IEnumerable<User>> GetPageIncludePersonAsync(UserRole role, int pageNumber, int pageSize, CancellationToken cancellationToken);
	}
}
