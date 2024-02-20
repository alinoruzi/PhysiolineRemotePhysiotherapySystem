namespace AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs
{
	public class GetSpecializedTitleListItemDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ColorCode { get; set; }
		public DateTime CreatedAt { get; set; }
		public long CreatorUserId { get; set; }
	}
}
