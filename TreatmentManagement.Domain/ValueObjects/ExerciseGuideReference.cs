namespace TreatmentManagement.Domain.ValueObjects
{
	public record ExerciseGuideReference
	{
		public long Id { get; init; }
		public long? ExerciseId { get; set; }
		public required string Title { get; set; }
		public required string Url { get; set; }
	}
}
