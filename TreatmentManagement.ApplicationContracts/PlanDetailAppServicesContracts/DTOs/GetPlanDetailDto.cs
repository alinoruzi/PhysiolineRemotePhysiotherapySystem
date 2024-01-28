namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs
{
	public class GetPlanDetailDto
	{
		public long Id { get; set; }
		public long PlanId { get; set; }
		public long CollectionId { get; set; }
		public List<byte> WeekDays { get; set; }
	}
}
