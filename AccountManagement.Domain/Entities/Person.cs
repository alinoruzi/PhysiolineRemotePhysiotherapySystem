using AccountManagement.Domain.Enums;
using Physioline.Framework.Domain;

namespace AccountManagement.Domain.Entities
{
	public abstract class Person : BaseEntity
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required DateTime BirthDate { get; set; }
		public required Gender Gender { get; set; }
		
		public User? User { get; set; }
		public long? UserId { get; set; }
	}

}
