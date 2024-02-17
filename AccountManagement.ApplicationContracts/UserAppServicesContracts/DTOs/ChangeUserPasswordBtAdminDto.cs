using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class ChangeUserPasswordBtAdminDto
	{
		[Required(ErrorMessage = "وورد شناسه کاربر ضروری است")]
		[RequiredId(ErrorMessage = "وورد شناسه کاربر ضروری است")]
		[Display(Name="شناسه کاربر")]
		public long UserId { get; set; }
        
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است.")]
		[MaxLength(2500, ErrorMessage = "طول رمز عبور معتبر نیست (حداکثر 255 کاراکتر)")]
		[Display(Name = "رمز عبور جدید", Description = "رمز عبور حساب کاربری خود را وارد کنید.")]
		public string Password { get; set; }
		
	}
}
