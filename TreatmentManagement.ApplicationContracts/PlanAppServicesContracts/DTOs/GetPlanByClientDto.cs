namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs
{
	public class GetPlanByClientDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long CreatorUserId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsActive { get; set; }
	}
}
