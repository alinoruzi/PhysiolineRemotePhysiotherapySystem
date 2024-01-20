using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs
{
	public class EditExerciseCategoryDto
	{
		[Required]
		[RequiredId]
		public long Id { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }

		[MaxLength(750)]
		public string Description { get; set; }
	}
}
