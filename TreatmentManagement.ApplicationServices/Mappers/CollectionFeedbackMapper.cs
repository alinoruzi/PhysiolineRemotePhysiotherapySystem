using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class CollectionFeedbackMapper
	{
		public static CollectionFeedback Map(AddCollectionFeedbackDto dto, long userId)
			=> new CollectionFeedback()
			{
				PlanId = dto.PlanId,
				CollectionId = dto.CollectionId,
				DoingState = dto.DoingState,
				CreatorUserId = userId
			};

		public static GetCollectionFeedbackListItemDto MapToItem(CollectionFeedback collectionFeedback)
			=> new GetCollectionFeedbackListItemDto()
			{
				Id = collectionFeedback.Id,
				CollectionId = collectionFeedback.CollectionId,
				Comment = collectionFeedback.Comment
			};
	}
}
