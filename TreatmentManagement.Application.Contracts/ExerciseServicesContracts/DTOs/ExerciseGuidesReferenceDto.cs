using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.Application.Contracts.ExerciseServicesContracts.DTOs
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
		public string Url { get; set; }
	}
}