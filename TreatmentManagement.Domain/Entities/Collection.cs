using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class Collection : BaseEntity
	{
		public required string Title { get; set; }
		public required string ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public required bool IsGlobal { get; set; }
		public List<CollectionDetail> Details { get; set; }
		public List<CollectionCategorization> Categorizations { get; set; }
		public List<PlanDetail> Plans { get; set; }
		
		public Collection()
		{
			Details = new List<CollectionDetail>();
			Categorizations = new List<CollectionCategorization>();
			Plans = new List<PlanDetail>();
		}
	}
}
