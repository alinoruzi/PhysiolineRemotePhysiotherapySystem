using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class CollectionDetail : BaseEntity
	{
		public required Collection Collection { get; set; }
		public required long CollectionId { get; set; }
		
		public required Exercise Exercise { get; set; }
		public required long ExerciseId { get; set; }

		public required uint NumberPerDuration { get; set; }
		public required uint SecondsOfDuration { get; set; }

		public required uint Priority { get; set; }
	}
}
