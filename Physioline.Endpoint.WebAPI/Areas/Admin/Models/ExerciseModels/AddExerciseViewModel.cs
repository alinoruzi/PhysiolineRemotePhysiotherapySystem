using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

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
		[MinLength(5)]
		[MaxLength(1000)]
		public string PicturePath { get; set; }

		[Required] [RequiredId] public long CategoryId { get; set; }

		[Required] public List<ExerciseGuidesReferenceDto> GuideReferences { get; set; }
	}
}
