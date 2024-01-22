namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs
{
	public class GetCollectionCategoryListItemDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public long CreatorUserId { get; set; }
	}
}
