using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class ExerciseCategoryMapper
	{
		public static ExerciseCategory Map(AddExerciseCategoryDto dto, long userId)
			=> new ExerciseCategory
			{
				Title = dto.Title,
				Description = dto.Description,
				CreatorUserId = userId
			};

		public static void MapForEdit(ExerciseCategory entity, EditExerciseCategoryDto dto)
		{
			entity.Title = dto.Title;
			entity.Description = dto.Description;
		}

		public static GetExerciseCategoryDto Map(ExerciseCategory entity)
			=> new GetExerciseCategoryDto
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description
			};

		public static GetExerciseCategoryListItemDto MapToListItem(ExerciseCategory entity)
			=> new GetExerciseCategoryListItemDto
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId
			};

		public static ExerciseCategorySearchResultDto MapToSearchResult(ExerciseCategory entity)
			=> new ExerciseCategorySearchResultDto
			{
				Id = entity.Id,
				Title = entity.Title
			};
	}
}
