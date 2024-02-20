using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs
{
	public class AddExerciseDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		[Display(Name = "عنوان تمرین")]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		[Display(Name = "توضیح کوتاه")]
		public string ShortDescription { get; set; }

		[MaxLength(2500)] 
		[Display(Name = "توضیح کامل")]
		public string LongDescription { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(1000)]
        [Display(Name = "تصویر تمرین")]
		public string PicturePath { get; set; }

		[Required] 
        [RequiredId]
        [Display(Name = "دسته بندی")]
        public long CategoryId { get; set; }

		[Required]
        [Display(Name = "منابع راهنما")]
        public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
	}
}
