using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionCategoryModels
{
	public class CollectionCategoryGetPageListViewModel
	{
		public List<GetCollectionCategoryListItemDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
