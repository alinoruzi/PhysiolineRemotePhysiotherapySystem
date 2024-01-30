using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class ExerciseGuidesReferenceDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(1000)]
		[Url]
		public string Url { get; set; }
	}
}
