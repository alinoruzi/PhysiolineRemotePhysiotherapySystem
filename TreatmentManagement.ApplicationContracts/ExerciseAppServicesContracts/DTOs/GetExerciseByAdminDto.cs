namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class GetExerciseByAdminDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public long StaticPictureFileId { get; set; }
		public long? AnimationPictureId { get; set; }
		public bool IsGlobal { get; set; }
		public DateTime CreatedAt { get; set; }
		public long UserCreatorId { get; set; }
		public List<long> CategoriesId { get; set; }
		public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
	}
}
