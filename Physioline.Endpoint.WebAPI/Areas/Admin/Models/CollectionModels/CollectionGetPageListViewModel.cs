using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionModels
{
	public class CollectionGetPageListViewModel
	{
		public List<GetCollectionListItemByAdminDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
