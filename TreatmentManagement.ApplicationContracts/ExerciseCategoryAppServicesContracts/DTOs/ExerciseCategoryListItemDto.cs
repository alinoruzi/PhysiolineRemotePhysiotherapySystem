namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs
{
	public class ExerciseCategoryListItemDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long UserCreatorId { get; set; }
	}
}
