using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs
{
	public class AddSpecializedTitleDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		[Display(Name = "عنوان تخصصی")]
		public string Title { get; set; }

		[Required]
		[Length(6,9)]
		[Display(Name = "رنگ شاخص")]
		public string ColorCode { get; set; }
	}

}
