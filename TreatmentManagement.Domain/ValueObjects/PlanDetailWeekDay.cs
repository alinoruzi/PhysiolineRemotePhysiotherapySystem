namespace TreatmentManagement.Domain.ValueObjects
{
	public record PlanDetailWeekDay
	{
		public required long Id { get; set; }
		public required long PlanDetailId { get; set; }
		public required DayOfWeek DayOfWeek { get; set; }
	}
}
