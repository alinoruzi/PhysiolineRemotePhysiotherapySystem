using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs
{
	public class SearchCollectionInputDto
	{
		[Required] [MaxLength(255)] public string Title { get; set; }
	}
}
