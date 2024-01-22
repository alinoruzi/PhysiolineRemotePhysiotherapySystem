using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class CollectionCategoryMapper
	{
		public static CollectionCategory Map( AddCollectionCategoryDto dto, long userId)
			=> new CollectionCategory
			{
				Title = dto.Title,
				Description = dto.Description,
				CreatorUserId = userId
			};

		public static void MapForEdit(CollectionCategory entity, EditCollectionCategoryDto dto)
		{
			entity.Title = dto.Title;
			entity.Description = dto.Description;
		}

		public static GetCollectionCategoryDto Map(CollectionCategory entity)
			=> new GetCollectionCategoryDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description
			};

		public static GetCollectionCategoryListItemDto MapToListItem(CollectionCategory entity)
			=> new GetCollectionCategoryListItemDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId,
			};
		
		public static CollectionCategorySearchResultDto MapToSearchResult(CollectionCategory entity)
		=> new CollectionCategorySearchResultDto()
		{
			Id = entity.Id,
			Title = entity.Title
		};
	}
}
