using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class SearchInputExerciseDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }
	}
}
