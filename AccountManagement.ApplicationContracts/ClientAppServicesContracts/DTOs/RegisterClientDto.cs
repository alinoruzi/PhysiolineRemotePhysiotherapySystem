using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs
{
	public class RegisterClientDto
	{
		[Required(ErrorMessage = "فیلد ایمیل ضروری است.")]
		[EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
		[Length(3,255,ErrorMessage = "طول ایمیل وارد شده متعبر نیست (بین 3 تا 255)")]
		[Display(Name = "ایمیل", Description = "ایمیلی که با آن پیش ثبت نام شده اید")]
		public string Username { get; set; }

		[Required(ErrorMessage = "فیلد موبایل ضروری است.")]
		[Phone(ErrorMessage = "ساختار موبایل وارد شده معتبر نیست")] 
		[Length(11,11,ErrorMessage = "طول موبایل 11 رقتم است (به همراه صفر وارد کنید)")] 
		[Display(Name = "شماره موبایل", Description = "موبایلی که با آن پیش ثبت نام شده اید")]
		public string Mobile { get; set; }
		
		
		[Required(ErrorMessage = "فیلد رمز عبور ضروری است.")]
		[Length(8,2500, ErrorMessage = "طول رمز حداقل 8 و حداکثر 2500 کاراکتر باشد.")]
		[Display(Name = "رمز عبور انتخابی")]
		public string Password { get; set; }
		
		[Required(ErrorMessage = "فیلد نام ضروری است.")]
		[Length(3,255,ErrorMessage = "طول نام حداقل 3 و حداکثر 255 کاراکتر باشد")]
		[Display(Name = "نام")]
		public string FirstName { get; set; }
		
		[Required(ErrorMessage = "فیلد نام خانوادگی ضروری است.")]
		[Length(3,255,ErrorMessage = "طول نام خانوادگی حداقل 3 و حداکثر 255 کاراکتر باشد")]
		[Display(Name = "نام خانوادگی")]
		public string LastName { get; set; }
		
		[Required(ErrorMessage = "فیلد جنسیت ضروری است.")]
		[Range(1,2)]
		[Display(Name = "جنسیت")]
		public uint Gender { get; set; }
		
		[Required(ErrorMessage = "فیلد کد ملی ضروری است.")]
		[Length(10,10, ErrorMessage = "طول کد ملی میبایست 10 رقم باشد.")]
		[Display(Name = "کد ملی")]
		public string NationalCode { get; set; }
		
		[Required(ErrorMessage = "فیلد تاریخ تولد ضروری است.")]
		[Display(Name = "تاریخ تولد")]
		public DateTime BirthDate { get; set; }
	}
}
