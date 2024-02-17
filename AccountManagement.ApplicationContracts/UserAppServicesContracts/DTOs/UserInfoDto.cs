namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class UserInfoDto
	{
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Role { get; set; }
		public bool IsRegistered { get; set; }
		public bool IsConfirmed { get; set; }
		
	}
}
