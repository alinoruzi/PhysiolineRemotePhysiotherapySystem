using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels
{
	public class ExerciseGetPageListViewModel
	{
		public List<GetExerciseListItemByAdminDto> Items { get; set; } 
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
