using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs
{
	public class SpecializedTitleSearchInputDto
	{
		[MaxLength(255)] 
		public string? Title { get; set; }
	}
}
