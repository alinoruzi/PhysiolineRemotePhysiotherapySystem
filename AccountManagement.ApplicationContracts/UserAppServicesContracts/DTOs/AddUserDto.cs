using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class AddUserDto
	{
		[Required]
		[EmailAddress]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		[Phone]
		[MaxLength(11)]
		public string Mobile { get; set; }
	}
}
