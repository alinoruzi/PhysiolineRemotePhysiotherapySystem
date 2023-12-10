namespace Physioline.Domain.Core.Entities
{
	public class ExerciseCategory
	{
		public long ExerciseId { get; set; }
		public Exercise Exercise { get; set; }

		public long CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
