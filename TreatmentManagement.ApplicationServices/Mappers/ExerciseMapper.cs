using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public abstract class ExerciseMapper
	{
		public static Exercise Map(AddExerciseDto dto, long creatorUserId)
			=> new Exercise
			{
				Title = dto.Title,
				ShortDescription = dto.ShortDescription,
				LongDescription = dto.LongDescription,
				PicturePath = dto.PicturePath,
				CategoryId = dto.CategoryId,
				CreatorUserId = creatorUserId,
				GuideReferences = dto.GuideReferences.Select(Map).ToList()
			};

		public static ExerciseGuideReference Map(ExerciseGuidesReferenceDto dto)
			=> new ExerciseGuideReference
			{
				Title = dto.Title,
				Url = dto.Url
			};
		
		public static ExerciseGuidesReferenceDto Map(ExerciseGuideReference dto)
			=> new ExerciseGuidesReferenceDto
			{
				Title = dto.Title,
				Url = dto.Url
			};
		
		public static void Map(Exercise entity, EditExerciseDto dto)
		{
			entity.Title = dto.Title;
			entity.ShortDescription = dto.ShortDescription;
			entity.LongDescription = dto.LongDescription;
			entity.PicturePath = dto.PicturePath;
			entity.CategoryId = dto.CategoryId;
			entity.GuideReferences = dto.GuideReferences.Select(Map).ToList();
		}

		public static GetExerciseByAdminDto MapToAdminDto(Exercise entity)
			=> new GetExerciseByAdminDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				IsGlobal = entity.IsGlobal,
				PicturePath = entity.PicturePath,
				CategoryId = entity.CategoryId,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId,
				GuideReferences = entity.GuideReferences.Select(Map).ToList()
			};

		public static GetExerciseByExpertDto MapToExpertDto(Exercise entity)
			=> new GetExerciseByExpertDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				IsGlobal = entity.IsGlobal,
				PicturePath = entity.PicturePath,
				CategoryId = entity.CategoryId,
				GuideReferences = entity.GuideReferences.Select(Map).ToList()
			};
		
		public static GetExerciseByClientDto MapToClientDto(Exercise entity)
			=> new GetExerciseByClientDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				PicturePath = entity.PicturePath,
				Category = entity.Category.Title,
				GuideReferences = entity.GuideReferences.Select(Map).ToList()
			};

		public static GetExerciseListItemByAdminDto MapToListItemByAdmin(Exercise entity)
			=> new GetExerciseListItemByAdminDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				CreatedAt = entity.CreatedAt,
				IsGlobal = entity.IsGlobal,
				CreatorUserId = entity.CreatorUserId
			};
		
		public static GetExerciseListItemByExpertDto MapToListItemByExpert(Exercise entity)
			=> new GetExerciseListItemByExpertDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				IsGlobal = entity.IsGlobal,
				PicturePath = entity.PicturePath,
				CtegoryId = entity.CategoryId
			};

		public static SearchResultExerciseDto MapToSearchResult(Exercise entity)
			=> new SearchResultExerciseDto()
			{
				Id = entity.Id,
				Title = entity.Title
			};
	}
}
