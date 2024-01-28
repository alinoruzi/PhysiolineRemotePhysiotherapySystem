using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class CollectionDetailMapper
	{
		public static CollectionDetail Map(AddCollectionDetailDto dto, long userId)
			=> new CollectionDetail
			{
				CollectionId = dto.CollectionId,
				ExerciseId = dto.ExerciseId,
				NumberPerDuration = dto.NumberPerDuration,
				SecondsOfDuration = dto.SecondsPerDuration,
				CreatorUserId = userId,
			};

		public static void Map(CollectionDetail entity, EditCollectionDetailDto dto)
		{
			entity.NumberPerDuration = dto.NumberPerDuration;
			entity.SecondsOfDuration = dto.SecondsPerDuration;
		}

		public static GetCollectionDetailItemDto Map(CollectionDetail entity)
			=> new GetCollectionDetailItemDto()
			{
				Id = entity.Id,
				ExerciseId = entity.ExerciseId,
				Priority = entity.Priority,
				NumberPerDuration = entity.NumberPerDuration,
				SecondsOfDuration = entity.SecondsOfDuration
			};
	}
}
