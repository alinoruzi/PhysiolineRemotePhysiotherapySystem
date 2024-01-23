using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class EditCollectionDto
	{
		[Required]
		[RequiredId]
		public long Id { get; set; }
		
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Title { get; set; }
		
		[Required]
		[MinLength(3)]
		[MaxLength(750)]
		public string ShortDescription { get; set; }
		
		[MaxLength(2500)]
		public string LongDescription { get; set; }
		
		[Required]
		[RequiredId]
		public long CategoryId { get; set; }
	}
}
