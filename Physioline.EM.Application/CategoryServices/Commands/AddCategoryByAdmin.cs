using Physioline.EM.Application.Abstraction.CategoryServices.Commands;
using Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.CommandRepositories;
using Physioline.EM.Domain.Repositories.QueryRepositories;
using Physioline.Shared.Application.Operators;

namespace Physioline.EM.Application.CategoryServices.Commands
{
	public class AddCategoryByAdmin: IAddCategoryByAdmin
	{
		private readonly ICategoryCommandRepository _categoryCommandRepository;
		private readonly ICategoryQueryRepository _categoryQueryRepository;
		public AddCategoryByAdmin(ICategoryCommandRepository categoryRepository, ICategoryQueryRepository categoryQueryRepository)
		{
			_categoryCommandRepository = categoryRepository;
			_categoryQueryRepository = categoryQueryRepository;
		}


		public async Task<OperationResult> Execute(InputCategoryDto inputCategoryDto, CancellationToken cancellationToken)
		{
			Category? parentCategory = null;
			
			if (inputCategoryDto.ParentId != null)
			{
				parentCategory = await _categoryQueryRepository.Get((long)inputCategoryDto.ParentId, cancellationToken);
			}

			var category = new Category
			(
				inputCategoryDto.Title,
				inputCategoryDto.Description,
				parentCategory,
				inputCategoryDto.CreatorUserId
			);
			await _categoryCommandRepository.Create(category, cancellationToken);
			await _categoryCommandRepository.Save(cancellationToken);
			
			return OperationResult.Success();
		}
	}
}
