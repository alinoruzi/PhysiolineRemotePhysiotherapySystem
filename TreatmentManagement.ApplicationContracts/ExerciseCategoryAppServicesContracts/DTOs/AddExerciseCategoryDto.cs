using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs
{
	public class AddExerciseCategoryDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }

		[MaxLength(750)]
		public string Description { get; set; }

		[Required]
		[RequiredId]
		public long CreatorUserId { get; set; }
	}
}
