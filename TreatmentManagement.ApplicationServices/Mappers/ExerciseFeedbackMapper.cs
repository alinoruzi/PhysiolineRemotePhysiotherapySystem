using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class ExerciseFeedbackMapper
	{
		public static ExerciseFeedback Map(AddExerciseFeedbackDto dto, long userId)
			=> new ExerciseFeedback
			{
				PlanId = dto.PlanId,
				ExerciseId = dto.ExerciseId,
				DoingState = dto.DoingState,
				CreatorUserId = userId
			};

		public static GetExerciseFeedbackListItemDto MapToItem(ExerciseFeedback exerciseFeedback)
			=> new GetExerciseFeedbackListItemDto()
			{
				Id = exerciseFeedback.Id,
				ExerciseId = exerciseFeedback.ExerciseId,
				Comment = exerciseFeedback.Comment
			};
	}
}
