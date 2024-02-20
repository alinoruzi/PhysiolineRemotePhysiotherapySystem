using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class ChangePasswordDto
	{
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است.")]
		[Length(8,2500, ErrorMessage = "طول رمز حداقل 8 و حداکثر 2500 کاراکتر باشد.")]
		[Display(Name = "رمز عبور قبلی")]
		public string OldPassword { get; set; }
		
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است.")]
		[Length(8,2500, ErrorMessage = "طول رمز حداقل 8 و حداکثر 2500 کاراکتر باشد.")]
		[Display(Name = "رمز عبور جدید")]
		public string NewPassword { get; set; }
	}
}
