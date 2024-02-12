
namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class GetUserListItemDto
	{
		public long Id { get; set; }
		public string Email { get; set; }
		public string FisrtName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string Role { get; set; }
	}
}
