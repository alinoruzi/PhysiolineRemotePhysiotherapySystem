using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.PlanModels
{
	public class PlanGetPageListViewModel
	{
		public List<GetPlanByAdminDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
