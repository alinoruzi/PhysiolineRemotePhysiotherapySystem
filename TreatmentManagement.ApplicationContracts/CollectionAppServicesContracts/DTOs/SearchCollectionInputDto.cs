using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class SearchCollectionInputDto
	{
		[MaxLength(255)] 
		public string? Title { get; set; }
	}
}
