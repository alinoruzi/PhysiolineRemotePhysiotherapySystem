using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs
{
	public class ExerciseCategorySearchInputDto
	{
		[MaxLength(255)]
		 public string? Title { get; set; }
	}
}
