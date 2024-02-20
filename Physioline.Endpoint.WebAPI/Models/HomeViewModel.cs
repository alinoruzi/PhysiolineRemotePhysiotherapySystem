using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Models
{
	public class HomeViewModel
	{
		public List<ExerciseModel> LastExercises { get; set; }
		
	}

	public class ExerciseModel
	{
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Picture { get; set; }
	}
	

}
