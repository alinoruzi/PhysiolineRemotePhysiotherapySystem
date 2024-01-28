using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class Plan : BaseEntity
	{
		public required string Title { get; set; }
		public required string Description { get; set; }
		public required long ClientUserId { get; set; }
		public DateTime StartDate { get; set; }
		public required DateTime EndDate { get; set; }
		public List<PlanDetail> Details { get; set; }
		
		public Plan()
		{
			Details = new List<PlanDetail>();
		}
	}
}
