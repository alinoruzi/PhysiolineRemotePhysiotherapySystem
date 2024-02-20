using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class Collection : BaseEntity
	{

		public Collection()
		{
			CollectionFeedbacks = new List<CollectionFeedback>();
			Details = new List<CollectionDetail>();
			Plans = new List<PlanDetail>();
		}
		public required string Title { get; set; }
		public required string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsGlobal { get; set; }
		public CollectionCategory Category { get; set; }
		public required long CategoryId { get; set; }
		public List<CollectionFeedback> CollectionFeedbacks { get; set; }
		public List<CollectionDetail> Details { get; set; }
		public List<PlanDetail> Plans { get; set; }
	}
}
