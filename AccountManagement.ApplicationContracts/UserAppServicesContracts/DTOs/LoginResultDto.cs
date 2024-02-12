using AccountManagement.Domain.Enums;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class LoginResultDto
	{
		public long UserId { get; set; }
		public string Role { get; set; }
	}

}
