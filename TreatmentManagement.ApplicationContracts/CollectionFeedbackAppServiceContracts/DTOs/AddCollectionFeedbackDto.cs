using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs
{
	public class AddCollectionFeedbackDto
	{
		[Required]
		[RequiredId] 
		public long PlanId { get; set; }

		[Required] 
		[RequiredId]
		public long CollectionId { get; set; }

		[Required] 
		public bool DoingState { get; set; }
		
		[Length(3, 750)] public string? Comment { get; set; }

	}
}
