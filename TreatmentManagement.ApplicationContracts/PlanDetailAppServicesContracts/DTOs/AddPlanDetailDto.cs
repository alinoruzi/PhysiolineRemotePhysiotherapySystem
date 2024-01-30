using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs
{
	public class AddPlanDetailDto
	{
		[Required] [RequiredId] public long PlanId { get; set; }

		[Required] [RequiredId] public long CollectionId { get; set; }

		[Required]
		[RequiredList(nameof(WeekDays))]
		public List<byte> WeekDays { get; set; }
	}

}
