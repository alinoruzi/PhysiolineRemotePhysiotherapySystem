using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels
{
	public class ExerciseGetPageListViewModel
	{
		public List<GetExerciseListItemByAdminDto> Exercises { get; set; }
		public int PageNumber { get; set; }
		public bool HasOperation { get; set; }
		public bool	IsSuccess { get; set; }
		public string Message { get; set; }

		public ExerciseGetPageListViewModel()
		{
			HasOperation = false;
			IsSuccess = false;
		}
	}
}
