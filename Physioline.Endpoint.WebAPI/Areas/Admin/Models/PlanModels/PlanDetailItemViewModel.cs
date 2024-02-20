namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.PlanModels
{
	public class PlanDetailItemViewModel
	{
		public long Id { get; set; }
		public long CollectionId { get; set; }
		public string CollectionTitle { get; set; }
		public string CollectionShortDescription { get; set; }
		public bool CollectionIsGlobal { get; set; }
		public uint Priority { get; set; }
		public List<byte> WeekDays { get; set; }
	}
}
