using Physioline.Framework.Application;
using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class AddExerciseDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public required string Title { get; set; }
		
		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public required string ShortDescription { get; set; }
		
		[Required(AllowEmptyStrings = true)]
		[MinLength(3)]
		[MaxLength(750)]
		public string? LongDescription { get; set; }
		
		[Required] public long PictureId { get; set; }
		
		[Required] public long CategoryId { get; set; }
		[Required] public long CreatorUserId { get; set; }

		[Required]
		public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
		
	}
}
