using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Endpoint.WebAPI.Areas.Admin.Views.Collection;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionModels
{
	public class CollectionGetViewModel
	{
		public GetCollectionByAdminDto Collection { get; set; }
		public string CategoryTitle { get; set; }
		
		public UserInfoDto CreatorUserInfo { get; set; }
		public List<CollectionDetailItemViewModel> Items { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
