using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.CollectionModels;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Models.ExerciseModels
{
	public class ExerciseGetViewModel
	{
		public GetExerciseByAdminDto Exercise { get; set; }
		public string CategoryTitle { get; set; }
		public UserInfoDto CreatorUserInfo { get; set; }
		public bool? OperationResult { get; set; }
		public string? Message { get; set; }
	}
}
