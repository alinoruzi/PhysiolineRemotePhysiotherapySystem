using Physioline.Domain.Core.DTOs;
using Physioline.Domain.Core.Entities;
using Physioline.Framework.Domain;

namespace Physioline.Domain.Core.Contracts.AppServices
{
	public interface ICategoryAppService
	{
		//Query Services:
		Task<CategoryDto> GetById(long id, CancellationToken cancellationToken);
		Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
		Task<List<CategoryDto>> GetAllParents(CancellationToken cancellationToken);
		Task<List<CategoryDto>> GetChildrenById(long id, CancellationToken cancellationToken);
		Task<List<CategoryDto>> GetAllDeleted(CancellationToken cancellationToken);

		//Command Services:
		Task<OperationResult> Add(CategoryDto categoryDto, CancellationToken cancellationToken);
		Task<OperationResult> Edit(long id, CategoryDto categoryDto, CancellationToken cancellationToken);
		Task<OperationResult> Delete(long id, CancellationToken cancellationToken);
		Task<OperationResult> Restore(long id, CancellationToken cancellationToken);
	}
}
