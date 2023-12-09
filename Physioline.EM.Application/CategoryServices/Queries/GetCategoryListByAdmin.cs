using Physioline.EM.Application.Abstraction.CategoryServices.Queries;
using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.QueryRepositories;
using System.Security.AccessControl;

namespace Physioline.EM.Application.CategoryServices.Queries
{
	public class GetCategoryListByAdmin : IGetCategoryListByAdmin
	{
		private readonly ICategoryQueryRepository _repository;
		public GetCategoryListByAdmin(ICategoryQueryRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<OutputCategoryDto>> Execute(CancellationToken cancellationToken)
		{
			var categories = await _repository.GetAll(cancellationToken);
			return ConvertCategoryToDto(categories);
		}

		List<OutputCategoryDto> ConvertCategoryToDto(List<Category> categories)
		{
			List<OutputCategoryDto> outputCategoryDtos = categories.Where(x=>x.IsDeleted == false)
				.Select(x => new OutputCategoryDto()
				{
					Id = x.Id,
					Title = x.Title,
					Parent = x.Parent == null ? null : 
						new OutputCategoryDto()
						{
							Id = x.Parent.Id,
							Title = x.Parent.Title,
							Description = x.Parent.Descriptin,
							CreatedAt = x.Parent.CreatedAt,
							ModifiedAt = x.Parent.ModifiedAt,
						},
					Children = x.Children == null ? new List<OutputCategoryDto>() : ConvertCategoryToDto(x.Children),
					CreatedAt = x.CreatedAt,
					ModifiedAt = x.ModifiedAt
				}).ToList();
			return outputCategoryDtos;
		}
		
	}
}
