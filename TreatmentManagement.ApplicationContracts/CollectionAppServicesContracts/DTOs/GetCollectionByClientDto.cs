namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class GetCollectionByClientDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public string Category { get; set; }
	}
}
