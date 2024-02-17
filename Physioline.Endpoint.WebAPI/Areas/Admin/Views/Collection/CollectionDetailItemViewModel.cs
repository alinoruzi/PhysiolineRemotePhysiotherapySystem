namespace Physioline.Endpoint.WebAPI.Areas.Admin.Views.Collection
{
	public class CollectionDetailItemViewModel
	{
		public long Id { get; set; }
		public uint Priority { get; set; }
		public long ExerciseId { get; set; }
		public uint NumberPerDuration { get; set; }
		public uint SecondsOfDuration { get; set; }
		public string ExerciseTitle { get; set; }
		public string ExercisePicturePath { get; set; }
		public string ExerciseShortDescription { get; set; }
	}
}
