using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs
{
	public class EditPlanDetailDto
	{
		[Required]
		[RequiredId]
		public long Id { get; set; }
		
		
		[Required]
		[RequiredList(nameof(WeekDays))]
		[Range(0,6)]
		public List<byte> WeekDays { get; set; }
	}
}
