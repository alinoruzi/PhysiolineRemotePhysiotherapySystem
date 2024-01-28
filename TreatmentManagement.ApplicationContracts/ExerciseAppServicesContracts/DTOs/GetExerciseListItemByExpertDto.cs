namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class GetExerciseListItemByExpertDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public bool IsGlobal { get; set; }
		public string PicturePath { get; set; }
		public long CtegoryId { get; set; }
	}
}
