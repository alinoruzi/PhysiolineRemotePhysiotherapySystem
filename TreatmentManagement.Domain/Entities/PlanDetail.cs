using Physioline.Framework.Domain;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Domain.Entities
{
	public class PlanDetail : BaseEntity
	{

		public PlanDetail()
		{
			WeekDays = new List<PlanDetailWeekDay>();
		}
		public Plan Plan { get; set; }
		public required long PlanId { get; set; }
		public Collection Collection { get; set; }
		public required long CollectionId { get; set; }
		public required uint Priority { get; set; }
		public List<PlanDetailWeekDay> WeekDays { get; set; }
	}
}
