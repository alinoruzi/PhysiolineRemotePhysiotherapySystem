using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class AddCollectionDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		[Display(Name="عنوان مجموعه")]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		[Display(Name="توضیح کوتاه")]
		public string ShortDescription { get; set; }

		[MaxLength(2500)]
		[Display(Name="شرح کامل")]
		public string? LongDescription { get; set; }
		
		[Required] 
		[RequiredId] 
		[Display(Name="دسته بندی")]
		public long CategoryId { get; set; }
	}

}
