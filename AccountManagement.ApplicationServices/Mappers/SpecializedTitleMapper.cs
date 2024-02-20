using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.Domain.Entities;

namespace AccountManagement.ApplicationServices.Mappers
{
	public class SpecializedTitleMapper
	{
		public static SpecializedTitle Map(AddSpecializedTitleDto dto, long userId)
			=> new SpecializedTitle
			{
				Title = dto.Title,
				ColorCode = dto.ColorCode,
				CreatorUserId = userId
			};

		public static void MapForEdit(SpecializedTitle entity, EditSpecializedTitleDto dto)
		{
			entity.Title = dto.Title;
			entity.ColorCode = dto.ColorCode;
		}

		public static GetSpecializedTitleDto Map(SpecializedTitle entity)
			=> new GetSpecializedTitleDto
			{
				Id = entity.Id,
				Title = entity.Title,
				ColorCode = entity.ColorCode
			};

		public static GetSpecializedTitleListItemDto MapToListItem(SpecializedTitle entity)
			=> new GetSpecializedTitleListItemDto
			{
				Id = entity.Id,
				Title = entity.Title,
				ColorCode = entity.ColorCode,
				CreatedAt = entity.CreatedAt,
				CreatorUserId = entity.CreatorUserId
			};

		public static SpecializedTitleSearchResultDto MapToSearchResult(SpecializedTitle entity)
			=> new SpecializedTitleSearchResultDto
			{
				Id = entity.Id,
				Title = entity.Title
			};
	}
}
