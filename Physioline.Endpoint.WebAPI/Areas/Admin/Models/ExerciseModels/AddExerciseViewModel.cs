using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using Physioline.Endpoint.WebAPI.CustomUtilities.Validations;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels
{
	public class AddExerciseViewModel
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public string ShortDescription { get; set; }

		[MaxLength(2500)] public string LongDescription { get; set; }

		[Required]
		[FileExtensions(Extensions = "png,jpg,gif")]
		[MaxFileSize(5 * 1024 * 1024)]
		public IFormFile Picture { get; set; }

		[Required] [RequiredId] public long CategoryId { get; set; }

		[Required] public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
	}
}
