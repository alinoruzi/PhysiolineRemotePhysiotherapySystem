using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs
{
	public record AddPlanDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(2500)]
		public string Description { get; set; }

		[Required] [RequiredId] public long ClientUserId { get; set; }

		[Required] [Range(1, 1000)] public uint PlanLength { get; set; }
	}

}
