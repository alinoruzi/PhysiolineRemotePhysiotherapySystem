using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class ExerciseCategory : BaseEntity
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public List<Exercise> Exercises { get; set; }

		public ExerciseCategory()
		{
			Exercises = new List<Exercise>();
		}
	}

}
