using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class LoginInputDto
	{
		[Required]
		[EmailAddress]
		public string Username { get; set; }
		
		[Required]
		[Length(8,2500)]
		public string Password { get; set; }
	}
}
