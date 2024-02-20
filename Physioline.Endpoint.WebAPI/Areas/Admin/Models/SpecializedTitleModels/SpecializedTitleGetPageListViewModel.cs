using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.SpecializedTitleModels
{
	public class SpecializedTitleGetPageListViewModel
	{
		public List<GetSpecializedTitleListItemDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
