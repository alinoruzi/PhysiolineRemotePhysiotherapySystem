using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs
{
	public class LoginInputDto
	{
		[Required(ErrorMessage = "فیلد نام کاربری ضروری است.")]
		[EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
		[Length(3,255,ErrorMessage = "طول ایمیل وارد شده متعبر نیست (بین 3 تا 255)")]
		[Display(Name = "نام کاربری (ایمیل)", Description = "ایمیل مربوط به حساب کاربری خود را وارد کنید.")]
		public string Username { get; set; }
		
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است.")]
		[MaxLength(2500, ErrorMessage = "طول رمز عبور معتبر نیست (حداکثر 255 کاراکتر)")]
		[Display(Name = "رمز عبور", Description = "رمز عبور حساب کاربری خود را وارد کنید.")]
		public string Password { get; set; }
	}
}
