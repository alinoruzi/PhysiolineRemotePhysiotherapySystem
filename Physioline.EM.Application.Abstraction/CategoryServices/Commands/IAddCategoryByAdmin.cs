using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;
using Physioline.Shared.Application.Operators;

namespace Physioline.EM.Application.Abstraction.CategoryServices.Commands
{
	public interface IAddCategoryByAdmin
	{
		Task<OperationResult> Execute(string title, string description, long? parentId,long creatorUserId, CancellationToken cancellationToken);
	}
}
