using Physioline.Domain.Core.Entities;

namespace Physioline.Domain.Core.Contracts.Repositories
{
	public interface ICategoryRepository
	{
		//Query:
		Task<Category> GetById(long id, CancellationToken cancellationToken);
		Task<bool> IsExistById(long id, CancellationToken cancellationToken);
		Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken);
		Task<List<Category>> GetAll(CancellationToken cancellationToken);
		Task<List<Category>> GetAllParents(CancellationToken cancellationToken);
		Task<List<Category>> GetChildrenById(long id, CancellationToken cancellationToken);
		Task<List<Category>> GetAllDeleted(CancellationToken cancellationToken);
		
		//Command:
		Task Create(Category category, CancellationToken cancellationToken);
		Task SaveChanges(CancellationToken cancellationToken);
	}
}
