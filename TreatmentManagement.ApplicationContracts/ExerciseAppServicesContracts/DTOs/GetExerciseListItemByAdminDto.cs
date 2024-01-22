namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class GetExerciseListItemByAdminDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public bool IsGlobal { get; set; }
		public DateTime CreatedAt { get; set; }
		public long CreatorUserId { get; set; }
	}
}
