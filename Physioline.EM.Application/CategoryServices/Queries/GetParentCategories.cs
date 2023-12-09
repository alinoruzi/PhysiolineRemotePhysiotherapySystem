using Physioline.EM.Application.Abstraction.CategoryServices.Queries;
using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;
using Physioline.EM.Domain.Repositories.QueryRepositories;

namespace Physioline.EM.Application.CategoryServices.Queries
{
	public class GetParentCategories :IGetParentCategories
	{
		private readonly ICategoryQueryRepository _repository;
		public GetParentCategories(ICategoryQueryRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<ParentCategoryDto>> Execute(CancellationToken cancellationToken)
		{
			var categories = await _repository.GetAll(cancellationToken);

			var parentCategories = categories.Where(x => x.ParentId == null).ToList();

			return parentCategories.Select(x => new ParentCategoryDto()
			{
				Id = x.Id,
				Title = x.Title,
			}).ToList();
		}
	}
}
