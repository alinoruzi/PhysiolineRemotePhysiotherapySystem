using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs
{
	public class AddCollectionCategoryDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		[Display(Name = "عنوان دسته بندی")]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		[Display(Name = "توضیحات دسته بندی")]
		public string Description { get; set; }
	}

}
