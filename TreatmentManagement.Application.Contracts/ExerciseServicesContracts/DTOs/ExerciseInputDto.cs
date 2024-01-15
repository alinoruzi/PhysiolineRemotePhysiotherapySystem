using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.Application.Contracts.ExerciseServicesContracts.DTOs
{
	public class ExerciseInputDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public required string Title { get; set; }
		
		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public required string ShortDescription { get; set; }
		
		[MinLength(3)]
		[MaxLength(750)]
		public string? LongDescription { get; set; }
		
		[Required] public long StaticPictureFileId { get; set; }
		
		public long? AnimationPictureFileId { get; set; }
		
		[Required] public long CreatorUserId { get; set; }


		[Required] public required List<long> ExerciseCategoriesId { get; set; }

		public List<ExerciseGuidesReferenceDto>? GuideReferences { get; set; }


	}
}
