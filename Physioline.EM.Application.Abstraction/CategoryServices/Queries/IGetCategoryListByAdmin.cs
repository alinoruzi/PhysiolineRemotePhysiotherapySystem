using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;

namespace Physioline.EM.Application.Abstraction.CategoryServices.Queries
{
	public interface IGetCategoryListByAdmin
	{
		Task<List<OutputCategoryDto>> Execute(CancellationToken cancellationToken);
	}
}
