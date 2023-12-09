using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Physioline.WebApp.Areas.Administration.Models
{
	public class CategoryCreateViewModel
	{
		[DisplayName("عنوان دسته بندی")]
		[MaxLength(255,ErrorMessage = "حداکثر 255 کاراکتر مجاز است")]
		[Required(ErrorMessage = "فیلد عنوان اجباری است.")]
		public string Title { get; set; }
		
		[DisplayName("توضیحات دسته بندی")]
		[MaxLength(2500,ErrorMessage = "حداکثر 2500 کاراکتر مجاز است")]
		public string Description { get; set; }
		
		[DisplayName("دسته والد")]
		public long? ParentId { get; set; }
	}
}
