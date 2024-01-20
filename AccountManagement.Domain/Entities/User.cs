using Microsoft.AspNetCore.Identity;

namespace AccountManagement.Domain.Entities
{
	public class User : IdentityUser<long>
	{
		public Person? Person { get; set; }
		public long? PersonId { get; set; }
	}
}
