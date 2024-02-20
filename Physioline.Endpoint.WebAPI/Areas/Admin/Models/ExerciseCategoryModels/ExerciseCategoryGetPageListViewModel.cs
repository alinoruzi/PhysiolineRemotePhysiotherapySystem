using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseCategoryModels
{
	public class ExerciseCategoryGetPageListViewModel
	{
		public List<GetExerciseCategoryListItemDto> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
