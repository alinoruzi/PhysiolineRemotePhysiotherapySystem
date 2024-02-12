using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class SearchInputExerciseDto
	{
		[MaxLength(255)] 
		public string? Title { get; set; }
	}
}
