namespace TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs
{
	public class GetExerciseFeedbackListItemDto
	{
		public long Id { get; set; }
		public long ExerciseId { get; set; }
		public string? Comment { get; set; }
	}
}
