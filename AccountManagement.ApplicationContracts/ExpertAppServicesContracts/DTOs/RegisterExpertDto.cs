using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs
{
	public class RegisterExpertDto
	{
		[Required]
		[EmailAddress]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required] 
		[Phone] 
		[MaxLength(11)] 
		public string Mobile { get; set; }
		
		
		[Required]
		[Length(8,2500)]
		public string Password { get; set; }
		
		[Required]
		[Length(3,255)]
		public string FirstName { get; set; }
		
		[Required]
		[Length(3,255)]
		public string LastName { get; set; }
		
		[Required]
		[Length(3,750)]
		public string Biography { get; set; }
		
		[Required]
		[Range(1,2)]
		public uint Gender { get; set; }
		
		[Required]
		[Length(10,10)]
		public string NationalCode { get; set; }
		
		[Required]
		[Length(3,10)]
		public string MedicalSystemCode { get; set; }
		
		[Required]
		[Length(3,1500)]
		public string ProfilePicturePath { get; set; }

		[Required]
		[RequiredId]
		public long SpecializedTitleId { get; set; }
	}
}
