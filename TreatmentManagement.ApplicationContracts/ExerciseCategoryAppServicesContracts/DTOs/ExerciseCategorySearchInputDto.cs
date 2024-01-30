using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs
{
	public class ExerciseCategorySearchInputDto
	{
		[Required] [MaxLength(255)] public string Title { get; set; }
	}
}
