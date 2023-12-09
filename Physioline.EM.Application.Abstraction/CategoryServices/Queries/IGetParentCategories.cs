using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;

namespace Physioline.EM.Application.Abstraction.CategoryServices.Queries
{
	public interface IGetParentCategories
	{
		Task<List<ParentCategoryDto>> Execute(CancellationToken cancellationToken);
	}
}
