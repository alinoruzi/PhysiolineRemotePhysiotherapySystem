using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.PlanModels
{
	public class PlanGetViewModel
	{
		public GetPlanByAdminDto Plan { get; set; }
		public List<PlanDetailItemViewModel> Details { get; set; }
		public ExpertInfoDto ExpertInfo { get; set; }
		public UserInfoDto ExpertUserInfo { get; set; }
		public UserInfoDto ClientUserInfo { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
