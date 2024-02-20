using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class CollectionFeedback : BaseEntity
	{
		public Plan Plan { get; set; }
		public required long PlanId { get; set; }
		
		public Collection Collection { get; set; }
		public required long CollectionId { get; set; }
		
		public required bool DoingState { get; set; }
		public string? Comment { get; set; }
	}
}
