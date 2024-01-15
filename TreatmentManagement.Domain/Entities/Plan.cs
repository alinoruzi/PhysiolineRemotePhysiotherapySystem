using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class Plan : BaseEntity
	{
		public required string Title { get; set; }
		public required string Description { get; set; }
		public required long ExpertId { get; set; }
		public required long ClientId { get; set; }
		public List<PlanDetail> Details { get; set; }
		
		public Plan()
		{
			Details = new List<PlanDetail>();
		}
	}
}
