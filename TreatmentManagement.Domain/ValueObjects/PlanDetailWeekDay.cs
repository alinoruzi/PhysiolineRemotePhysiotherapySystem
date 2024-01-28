namespace TreatmentManagement.Domain.ValueObjects
{
	public record PlanDetailWeekDay
	{
		public long Id { get; set; }
		public long? PlanDetailId { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
	}
}
