using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class ExerciseCategory : BaseEntity
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public long? ParentId { get; set; }
		public ExerciseCategory? Parent { get; set; }
		public List<ExerciseCategory> Children { get; set; }
		public List<ExerciseCategorization> Categorizations { get; set; }
		public List<Exercise> Exercises { get; set; }

		public ExerciseCategory()
		{
			Children = new List<ExerciseCategory>();
			Categorizations = new List<ExerciseCategorization>();
			Exercises = new List<Exercise>();
		}
	}

}
