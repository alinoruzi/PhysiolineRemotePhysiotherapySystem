namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class GetExerciseByExpertDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public bool IsGlobal { get; set; }
		public string PicturePath { get; set; }
		public long CategoryId { get; set; }
		public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
	}
}
