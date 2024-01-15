using Physioline.Framework.Domain;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Domain.Entities
{
	public class Exercise : BaseEntity
	{
		public required string Title { get; set; }
		public required string ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public required bool IsGlobal { get; set; }
		public List<ExerciseFile> Files { get; set; }
		public List<ExerciseCategorization> Categorizations { get; set; }
		public List<ExerciseCategory> Categories { get; set; }
		public List<ExerciseGuideReference> GuideReferences { get; set; }
		public List<CollectionDetail> Collections { get; set; }

		public Exercise()
		{
			Files = new List<ExerciseFile>();
			Categorizations = new List<ExerciseCategorization>();
			GuideReferences = new List<ExerciseGuideReference>();
			Collections = new List<CollectionDetail>();
			Categories = new List<ExerciseCategory>();
		}
	}

}
