using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class ExerciseCategorization
	{
		public Exercise? Exercise { get; set; }
		public required long ExerciseId { get; set; }

		public  ExerciseCategory? ExerciseCategory { get; set; }
		public required long ExerciseCategoryId { get; set; }
	}
}
