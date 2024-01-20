using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class ExerciseCategoryMapper
	{
		public static ExerciseCategory Map(AddExerciseCategoryDto dto)
			=> new ExerciseCategory
			{
				Title = dto.Title,
				Description = dto.Description,
				CreatorUserId = dto.CreatorUserId
			};

		public static void Map(ExerciseCategory entity, EditExerciseCategoryDto dto)
		{
			entity.Title = dto.Title;
			entity.Description = dto.Description;
		}

		public static GetExerciseCategoryDto Map(ExerciseCategory entity)
			=> new GetExerciseCategoryDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description
			};

		public static ExerciseCategoryListItemDto MapToListItem(ExerciseCategory entity)
			=> new ExerciseCategoryListItemDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				UserCreatorId = entity.CreatorUserId
			};

	}
}
