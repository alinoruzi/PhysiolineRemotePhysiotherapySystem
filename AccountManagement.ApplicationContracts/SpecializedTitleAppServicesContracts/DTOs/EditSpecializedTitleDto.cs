using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs
{
	public class EditSpecializedTitleDto
	{
		[Required] 
		[RequiredId] 
		public long Id { get; set; }

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
