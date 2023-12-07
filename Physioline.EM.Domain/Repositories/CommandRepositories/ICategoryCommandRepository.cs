using Physioline.EM.Domain.Entities;
using Physioline.Shared.Domain.Repositories;

namespace Physioline.EM.Domain.Repositories.CommandRepositories
{
	public interface ICategoryCommandRepository: IBaseCommandRepository<long, Category>
	{
		
	}
}
