using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs
{
	public class CollectionCategorySearchInputDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public string Title { get; set; }
	}
}
