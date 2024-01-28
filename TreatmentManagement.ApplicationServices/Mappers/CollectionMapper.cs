using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class CollectionMapper
	{
		public static Collection Map(AddCollectionDto dto, long userId)
			=> new Collection
			{
				Title = dto.Title,
				ShortDescription = dto.ShortDescription,
				LongDescription = dto.LongDescription,
				CategoryId = dto.CategoryId,
				CreatorUserId = userId
			};

		public static void Map(Collection entity, EditCollectionDto dto)
		{
			entity.Title = dto.Title;
			entity.ShortDescription = dto.ShortDescription;
			entity.LongDescription = dto.LongDescription;
			entity.CategoryId = dto.CategoryId;
		}

		public static GetCollectionByAdminDto MapToAdminDto(Collection entity)
			=> new GetCollectionByAdminDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				IsGlobal = entity.IsGlobal,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId
			};
		
		public static GetCollectionByExpertDto MapToExpertDto(Collection entity)
			=> new GetCollectionByExpertDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				IsGlobal = entity.IsGlobal,
				CategoryId = entity.CategoryId,
			};

		public static GetCollectionListItemByAdminDto MapToAdminItem(Collection entity)
			=> new GetCollectionListItemByAdminDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				IsGlobal = entity.IsGlobal,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId
			};

		public static GetCollectionByClientDto MapToClientDto(Collection entity)
			=> new GetCollectionByClientDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				LongDescription = entity.LongDescription,
				Category = entity.Category.Title
			};
		
		public static GetCollectionListItemByExpertDto MapToExpertItem(Collection entity)
			=> new GetCollectionListItemByExpertDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				ShortDescription = entity.ShortDescription,
				IsGlobal = entity.IsGlobal,
				CategoryId = entity.CategoryId
			};
		

		public static SearchCollectionOutputDto MapToSearchResult(Collection entity)
			=> new SearchCollectionOutputDto()
			{
				Id = entity.Id,
				Title = entity.Title
			};

	}
}
