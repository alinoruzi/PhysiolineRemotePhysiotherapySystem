using Physioline.Domain.Core.Contracts.AppServices;
using Physioline.Domain.Core.Contracts.Repositories;
using Physioline.Domain.Core.DTOs;
using Physioline.Domain.Core.Entities;
using Physioline.Framework.Domain;

namespace Physioline.Domain.Service.AppServices
{
	public class CategoryAppService : ICategoryAppService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryAppService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		#region Query Services:

		public async Task<CategoryDto> GetById(long id, CancellationToken cancellationToken)
		{
			if (!await _categoryRepository.IsExistById(id, cancellationToken))
				throw new Exception("There is no --Category-- record with the entered Id.");

			var category = await _categoryRepository.GetById(id, cancellationToken);
			var categoryDto = new CategoryDto()
			{
				Id = category.Id,
				Title = category.Title,
				Description = category.Description,
				ParentId = category.ParentId,
				CreatedAt = category.CreatedAt
			};

			return categoryDto;
		}

		public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
		{
			var categories = await _categoryRepository.GetAll(cancellationToken);
			var categoriesDto = categories.Select(c => new CategoryDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return categoriesDto;
		}

		public async Task<List<CategoryDto>> GetAllParents(CancellationToken cancellationToken)
		{
			var categories = await _categoryRepository.GetAllParents(cancellationToken);
			var categoriesDto = categories.Select(c => new CategoryDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return categoriesDto;
		}

		public async Task<List<CategoryDto>> GetChildrenById(long id, CancellationToken cancellationToken)
		{
			if (!await _categoryRepository.IsExistById(id, cancellationToken))
				throw new Exception("There is no --Category-- record with the entered Id.");

			var category = await _categoryRepository.GetById(id, cancellationToken);

			if (category.ParentId != null)
				throw new Exception("The record is not a parent category.");

			var categoryChildren = await _categoryRepository.GetChildrenById(id, cancellationToken);

			var childrenCategoriesDto = categoryChildren.Select(c => new CategoryDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return childrenCategoriesDto;
		}

		public async Task<List<CategoryDto>> GetAllDeleted(CancellationToken cancellationToken)
		{
			var categories = await _categoryRepository.GetAllDeleted(cancellationToken);
			var categoriesDto = categories.Select(c => new CategoryDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return categoriesDto;
		}

		#endregion

		#region Command Services:

		public async Task<OperationResult> Add(CategoryDto categoryDto, CancellationToken cancellationToken)
		{
			if (await _categoryRepository.IsExistByTitle(categoryDto.Title, cancellationToken))
				return OperationResult.Failed("The specified name for the category already exists.");

			Category? parentCategory = null;
			
			if (categoryDto.ParentId != null)
			{
				if (! await _categoryRepository.IsExistById((long)categoryDto.ParentId,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.");

				parentCategory = await _categoryRepository.GetById((long)categoryDto.ParentId, cancellationToken);
				
				if (parentCategory.IsDeleted || parentCategory.ParentId != null)
					return OperationResult.Failed("The specified parent category has been removed or is not a parent category.");
			}

			var category = new Category()
			{
				Title = categoryDto.Title,
				Description = categoryDto.Description,
				CreatedAt = DateTime.Now,
				ParentId = categoryDto.ParentId,
				Parent = parentCategory,
				IsDeleted = false
			};

			await _categoryRepository.Create(category, cancellationToken);
			parentCategory.Children.Add(category);
			await _categoryRepository.SaveChanges(cancellationToken);
			
			return OperationResult.Success();
		}

		public async Task<OperationResult> Edit(long id, CategoryDto categoryDto, CancellationToken cancellationToken)
		{ 
			if (! await _categoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.");

			var category = await _categoryRepository.GetById(id, cancellationToken);

			if (category.Title != categoryDto.Title)
			{
				if (await _categoryRepository.IsExistByTitle(categoryDto.Title, cancellationToken))
					return OperationResult.Failed("The specified name for the category already exists.");
			}

			Category? newParentCategory = null;
			if (category.ParentId != categoryDto.ParentId && category.ParentId != null)
			{
				if (! await _categoryRepository.IsExistById((long)categoryDto.ParentId!,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.");

				newParentCategory = await _categoryRepository.GetById((long)categoryDto.ParentId, cancellationToken);
				
				if (newParentCategory.IsDeleted || newParentCategory.ParentId != null)
					return OperationResult.Failed("The specified parent category has been removed or is not a parent category.");

				Category? lastParent = await _categoryRepository.GetById((long)category.ParentId, cancellationToken);

				lastParent.Children.Remove(category);
				newParentCategory.Children.Add(category);
			}

			category.Title = categoryDto.Title;
			category.Description = categoryDto.Description;
			category.ParentId = categoryDto.ParentId;
			category.Parent = newParentCategory;
			
			await _categoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}

		public async Task<OperationResult> Delete(long id, CancellationToken cancellationToken)
		{ 
			if (! await _categoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.");

			var category = await _categoryRepository.GetById(id, cancellationToken);
			foreach (var item in category.Children)
			{
				item.ParentId = null;
			}

			category.Children = new List<Category>();
			
			if (category.ParentId != null)
			{
				if (! await _categoryRepository.IsExistById((long)category.ParentId!,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.");
				
				var parentCategory = await _categoryRepository.GetById((long)category.ParentId, cancellationToken);

				parentCategory.Children.Remove(category);
			}

			category.ParentId = null;
			category.Parent = null;
			category.IsDeleted = true;

			await _categoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}
		
		public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
		{ 
			if (! await _categoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.");
			
			var category = await _categoryRepository.GetById(id, cancellationToken);
			if (! category.IsDeleted)
				return OperationResult.Failed("Category object did not delete.");

			category.IsDeleted = false;
			
			await _categoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}

		#endregion

	}
}
