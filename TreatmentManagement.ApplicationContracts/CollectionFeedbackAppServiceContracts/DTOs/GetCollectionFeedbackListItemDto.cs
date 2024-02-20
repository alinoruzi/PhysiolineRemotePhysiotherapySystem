namespace TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs
{
	public class GetCollectionFeedbackListItemDto
	{
		public long Id { get; set; }
		public long CollectionId { get; set; }
		public string? Comment { get; set; }
	}
}
