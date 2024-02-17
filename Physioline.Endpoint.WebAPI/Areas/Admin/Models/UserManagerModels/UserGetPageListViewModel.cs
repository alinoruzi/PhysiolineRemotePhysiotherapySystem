using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.UserManagerModels
{
	public class UserGetPageListViewModel
	{
		public List<GetUserListItemDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string Role { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
