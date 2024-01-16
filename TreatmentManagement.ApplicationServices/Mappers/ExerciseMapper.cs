using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public abstract class ExerciseMapper
	{
		public static Exercise Map(AddExerciseDto dto)
			=> new Exercise
			{
				Title = dto.Title,
				ShortDescription = dto.ShortDescription,
				LongDescription = dto.LongDescription,
				PictureId = 0,
				CategoryId = dto.CategoryId,
				CreatorUserId = dto.CreatorUserId,
				IsGlobal = false
			};

		public static ExerciseGuideReference Map(ExerciseGuidesReferenceDto dto)
			=> new ExerciseGuideReference
			{
				Title = dto.Title,
				Url = dto.Url
			};

		public static GetExerciseByAdminDto Map(Exercise entity)
			=> new GetExerciseByAdminDto()
			{
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				StaticPictureFileId = 0,
				AnimationPictureId = 0,
				IsGlobal = entity.IsGlobal,
				CreatedAt = entity.CreatedAt,
				UserCreatorId = entity.CreatorUserId,
			};
	}
}
