using Physioline.Framework.Domain;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Domain.Entities
{
	public class Exercise : BaseEntity
	{
		public required string Title { get; set; }
		public required string ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public bool IsGlobal { get; set; }
		public List<ExerciseFile> Files { get; set; }
		public List<ExerciseCategory> Categories { get; set; }
		public List<CollectionDetail> Collections { get; set; }
		public List<ExerciseGuideReference> GuideReferences { get; set; }

		public Exercise()
		{
			Files = new List<ExerciseFile>();
			Categories = new List<ExerciseCategory>();
			GuideReferences = new List<ExerciseGuideReference>();
			Collections = new List<CollectionDetail>();
			IsGlobal = false;
		}
	}

}
