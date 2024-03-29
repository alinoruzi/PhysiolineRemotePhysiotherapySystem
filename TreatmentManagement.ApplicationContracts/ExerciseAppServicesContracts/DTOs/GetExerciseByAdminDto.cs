namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class GetExerciseByAdminDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsGlobal { get; set; }
		public string PicturePath { get; set; }
		public long CategoryId { get; set; }
		public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
		public DateTime CreatedAt { get; set; }
		public long CreatorUserId { get; set; }
	}

}
