using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs
{
	public class AddCollectionCategoryDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }
		
		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public string Description { get; set; }
	}

}
