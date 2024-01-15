namespace TreatmentManagement.Domain.Entities
{
	public class CollectionCategorization
	{
		public required Collection Collection { get; set; }
		public required long CollectionId { get; set; }

		public required CollectionCategory CollectionCategory { get; set; }
		public required long CollectionCategoryId { get; set; }
	}
}
