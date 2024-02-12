using AccountManagement.Domain.Enums;
using Physioline.Framework.Domain;

namespace AccountManagement.Domain.Entities
{
	public class User : BaseEntity
	{

		public User()
		{
			IsConfirmed = false;
			IsRegistered = false;
			UserRole = UserRole.Client;
		}
		public required string Email { get; set; }
		public required string Mobile { get; set; }
		public string? Password { get; set; }
		public bool IsConfirmed { get; set; }
		public bool IsRegistered { get; set; }
		public UserRole UserRole { get; set; }
		public Person Person { get; set; }
		public long? PersonId { get; set; }
	}
}
