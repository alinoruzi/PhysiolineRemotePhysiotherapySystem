namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs
{
	public class GetCollectionDetailItemDto
	{
		public long Id { get; set; }
		public uint Priority { get; set; }
		public long ExerciseId { get; set; }
		public uint NumberPerDuration { get; set; }
		public uint SecondsOfDuration { get; set; }
	}
}
