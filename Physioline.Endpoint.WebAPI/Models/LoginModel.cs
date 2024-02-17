using System.ComponentModel.DataAnnotations;

namespace Physioline.Endpoint.WebAPI.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "فیلد نام کاربری (ایمیل) ضروری است")]
		[Length(3,255,ErrorMessage = "طول ایمیل بین 3 تا 255 کاراکتر باشد")]
		public string Username { get; set; }
		
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است")]
		[Length(8,2500,ErrorMessage = "طول رمز عبور بین 8 تا 2500 کاراکتر باشد")]
		public string Password { get; set; }
	}
}
