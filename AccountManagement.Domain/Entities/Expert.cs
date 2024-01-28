using Physioline.Framework.Domain;

namespace AccountManagement.Domain.Entities
{
	public class Expert : Person
	{
		public required string NationalCode { get; set; }
		public required string MedicalSystemCode { get; set; }
		public required string ProfilePicturePath { get; set; }
		public SpecializedTitle SpecializedTitle { get; set; }
		public required long SpecializedTitleId { get; set; }
	}
}
