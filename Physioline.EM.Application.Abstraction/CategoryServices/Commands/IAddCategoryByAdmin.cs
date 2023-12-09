using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;
using Physioline.Shared.Application.Operators;

namespace Physioline.EM.Application.Abstraction.CategoryServices.Commands
{
	public interface IAddCategoryByAdmin
	{
		Task<OperationResult> Execute(InputCategoryDto inputCategoryDto, CancellationToken cancellationToken);
	}
}
