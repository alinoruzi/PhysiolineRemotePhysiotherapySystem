using Physioline.Framework.Application;
using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.AdminDTOs;
using TreatmentManagement.ApplicationContracts.AdminServices;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;

namespace TreatmentManagement.ApplicationServices.AppServices
{
	public class ExerciseCategoryAdminService : IExerciseCategoryAdminService
	{
		private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
		public ExerciseCategoryAdminService(IExerciseCategoryRepository exerciseCategoryRepository)
		{
			_exerciseCategoryRepository = exerciseCategoryRepository;
		}

		#region Query Services:

		public async Task<OutputExerciseCategoryAdminDto> GetById(long id, CancellationToken cancellationToken)
		{
			if (!await _exerciseCategoryRepository.IsExistById(id, cancellationToken))
				throw new Exception("There is no --Category-- record with the entered Id.");

			var category = await _exerciseCategoryRepository.GetById(id, cancellationToken);
			var categoryDto = new OutputExerciseCategoryAdminDto()
			{
				Id = category.Id,
				Title = category.Title,
				Description = category.Description,
				ParentId = category.ParentId,
				CreatedAt = category.CreatedAt
			};

			return categoryDto;
		}

		public async Task<List<OutputExerciseCategoryAdminDto>> GetAll(CancellationToken cancellationToken)
		{
			var categories = await _exerciseCategoryRepository.GetAll(cancellationToken);
			var categoriesDto = categories.Select(c => new OutputExerciseCategoryAdminDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return categoriesDto;
		}

		public async Task<List<OutputExerciseCategoryAdminDto>> GetAllParents(CancellationToken cancellationToken)
		{
			var categories = await _exerciseCategoryRepository.GetAllParents(cancellationToken);
			var categoriesDto = categories.Select(c => new OutputExerciseCategoryAdminDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return categoriesDto;
		}

		public async Task<List<OutputExerciseCategoryAdminDto>> GetChildrenById(long id, CancellationToken cancellationToken)
		{
			if (!await _exerciseCategoryRepository.IsExistById(id, cancellationToken))
				throw new Exception("There is no --Category-- record with the entered Id.");

			var category = await _exerciseCategoryRepository.GetById(id, cancellationToken);

			if (category.ParentId != null)
				throw new Exception("The record is not a parent category.");

			var categoryChildren = await _exerciseCategoryRepository.GetChildrenById(id, cancellationToken);

			var childrenCategoriesDto = categoryChildren.Select(c => new OutputExerciseCategoryAdminDto()
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				ParentId = c.ParentId,
				CreatedAt = c.CreatedAt
			}).ToList();

			return childrenCategoriesDto;
		}

		public async Task<List<OutputExerciseCategoryAdminDto>> GetAllDeleted(CancellationToken cancellationToken)
		{
			var categories = await _exerciseCategoryRepository.GetAllDeleted(cancellationToken);
			var categoriesDto = categories.Select(c => new OutputExerciseCategoryAdminDto()
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

		public async Task<OperationResult> Add(InputExerciseCategoryAdminDto exerciseCategoryAdminDto, CancellationToken cancellationToken)
		{
			if (await _exerciseCategoryRepository.IsExistByTitle(exerciseCategoryAdminDto.Title, cancellationToken))
				return OperationResult.Failed("The specified name for the category already exists.",HttpStatusCode.ExpectationFailed);

			ExerciseCategory? parentCategory = null;
			
			if (exerciseCategoryAdminDto.ParentId != null)
			{
				if (! await _exerciseCategoryRepository.IsExistById((long)exerciseCategoryAdminDto.ParentId,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.",HttpStatusCode.ExpectationFailed);

				parentCategory = await _exerciseCategoryRepository.GetById((long)exerciseCategoryAdminDto.ParentId, cancellationToken);
				
				if (parentCategory.IsDeleted || parentCategory.ParentId != null)
					return OperationResult.Failed("The specified parent category has been removed or is not a parent category.",HttpStatusCode.ExpectationFailed);
			}

			var category = new ExerciseCategory
			{
				Title = exerciseCategoryAdminDto.Title,
				Description = exerciseCategoryAdminDto.Description,
				CreatedAt = DateTime.Now,
				ParentId = exerciseCategoryAdminDto.ParentId,
				Parent = parentCategory,
				IsDeleted = false,
				CreatorUserId = 0,
			};

			await _exerciseCategoryRepository.Create(category, cancellationToken);
			parentCategory?.Children.Add(category);
			await _exerciseCategoryRepository.SaveChanges(cancellationToken);
			
			return OperationResult.Success();
		}

		public async Task<OperationResult> Edit(long id, InputExerciseCategoryAdminDto exerciseCategoryAdminDto, CancellationToken cancellationToken)
		{ 
			if (! await _exerciseCategoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.",HttpStatusCode.ExpectationFailed);

			var category = await _exerciseCategoryRepository.GetById(id, cancellationToken);

			if (category.Title != exerciseCategoryAdminDto.Title)
			{
				if (await _exerciseCategoryRepository.IsExistByTitle(exerciseCategoryAdminDto.Title, cancellationToken))
					return OperationResult.Failed("The specified name for the category already exists.",HttpStatusCode.ExpectationFailed);
			}

			ExerciseCategory? newParentCategory = null;
			if (category.ParentId != exerciseCategoryAdminDto.ParentId && category.ParentId != null)
			{
				if (! await _exerciseCategoryRepository.IsExistById((long)exerciseCategoryAdminDto.ParentId!,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.",HttpStatusCode.ExpectationFailed);

				newParentCategory = await _exerciseCategoryRepository.GetById((long)exerciseCategoryAdminDto.ParentId, cancellationToken);
				
				if (newParentCategory.IsDeleted || newParentCategory.ParentId != null)
					return OperationResult.Failed("The specified parent category has been removed or is not a parent category.",HttpStatusCode.ExpectationFailed);

				ExerciseCategory? lastParent = await _exerciseCategoryRepository.GetById((long)category.ParentId, cancellationToken);

				lastParent.Children.Remove(category);
				newParentCategory.Children.Add(category);
			}

			category.Title = exerciseCategoryAdminDto.Title;
			category.Description = exerciseCategoryAdminDto.Description;
			category.ParentId = exerciseCategoryAdminDto.ParentId;
			category.Parent = newParentCategory;
			
			await _exerciseCategoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}

		public async Task<OperationResult> Delete(long id, CancellationToken cancellationToken)
		{ 
			if (! await _exerciseCategoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.",HttpStatusCode.ExpectationFailed);

			var category = await _exerciseCategoryRepository.GetById(id, cancellationToken);
			foreach (var item in category.Children)
			{
				item.ParentId = null;
			}

			category.Children = new List<ExerciseCategory>();
			
			if (category.ParentId != null)
			{
				if (! await _exerciseCategoryRepository.IsExistById((long)category.ParentId!,cancellationToken))
					return OperationResult.Failed("The specified parent category does not exist.",HttpStatusCode.ExpectationFailed);
				
				var parentCategory = await _exerciseCategoryRepository.GetById((long)category.ParentId, cancellationToken);

				parentCategory.Children.Remove(category);
			}

			category.ParentId = null;
			category.Parent = null;
			category.IsDeleted = true;

			await _exerciseCategoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}
		
		public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
		{ 
			if (! await _exerciseCategoryRepository.IsExistById(id, cancellationToken))
				return OperationResult.Failed("There is no --Category-- record with the entered Id.",HttpStatusCode.ExpectationFailed);
			
			var category = await _exerciseCategoryRepository.GetById(id, cancellationToken);
			if (! category.IsDeleted)
				return OperationResult.Failed("Category object did not delete.",HttpStatusCode.ExpectationFailed);

			category.IsDeleted = false;
			
			await _exerciseCategoryRepository.SaveChanges(cancellationToken);
			return OperationResult.Success();
		}

		#endregion

	}
}
