using Physioline.Framework.Domain;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Domain.Entities
{
	public class PlanDetail : BaseEntity
	{
		public required Plan Plan { get; set; }
		public required long PlanId { get; set; }
		
		public required Collection Collection { get; set; }
		public required long CollectionId { get; set; }

		public required uint Priority { get; set; }
		
		public required DateTime StartCollection { get; set; }
		public required DateTime EndCollection { get; set; }

		public List<PlanDetailWeekDay> WeekDays { get; set; }

		public PlanDetail()
		{
			WeekDays = new List<PlanDetailWeekDay>();
		}
	}
}
