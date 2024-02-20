using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.AdminAppServicesContracts.DTOs
{
	public class RegisterAdminDto
	{
		[Required]
		[EmailAddress]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required] 
		[MaxLength(11)]
		public string Mobile { get; set; }
		
		[Required]
		[Length(8,2500)]
		public string Password { get; set; }
		
		[Required]
		[Length(3,255)]
		public string FirstName { get; set; }
		
		[Required]
		[Length(3,255)]
		public string LastName { get; set; }
		
		[Required]
		[Range(1,2)]
		public uint Gender { get; set; }
	}
}
