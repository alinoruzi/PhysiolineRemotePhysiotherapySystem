using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class ExerciseFeedback : BaseEntity
	{
		public Plan Plan { get; set; }
		public required long PlanId { get; set; }

		public Exercise Exercise { get; set; }
		public required long ExerciseId { get; set; }

		public required bool DoingState { get; set; }
		public string? Comment { get; set; }
	}
}
