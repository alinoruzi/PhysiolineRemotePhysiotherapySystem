using System.ComponentModel.DataAnnotations;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.UserManagerModels
{
	public class PreRegisterViewModel
	{
		[Required]
		public int RoleNumber { get; set; }
		
		[Required]
		[EmailAddress]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		[MaxLength(11)]
		public string Mobile { get; set; }
	}
}
