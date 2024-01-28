namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class GetCollectionListItemByExpertDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public bool IsGlobal { get; set; }
		public long CategoryId { get; set; }
		
	}
}
