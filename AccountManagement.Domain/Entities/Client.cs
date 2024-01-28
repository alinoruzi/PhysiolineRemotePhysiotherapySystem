namespace AccountManagement.Domain.Entities
{
	public class Client : Person
	{
		public required string NationalCode { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
