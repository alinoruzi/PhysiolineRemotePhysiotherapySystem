namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs
{
	public class GetCollectionDetailItemDto
	{
		public long Id { get; set; }
		public uint Priority { get; set; }
		public long CollectionId { get; set; }
		public long ExerciseId { get; set; }
	}
}
