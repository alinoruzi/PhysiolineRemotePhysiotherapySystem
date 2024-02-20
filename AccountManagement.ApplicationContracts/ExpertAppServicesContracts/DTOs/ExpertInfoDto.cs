namespace AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs
{
	public class ExpertInfoDto
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public long SpecializedTitleId { get; set; }
		public string NationalCode { get; set; }
		public string MedicalSystemCode { get; set; }
		public string Biography { get; set; }
		public string ProfilePicture { get; set; }
	}
}
