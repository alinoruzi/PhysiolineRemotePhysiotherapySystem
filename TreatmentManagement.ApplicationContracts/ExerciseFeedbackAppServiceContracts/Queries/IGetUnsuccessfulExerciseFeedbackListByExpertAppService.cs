using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Queries
{
	public interface IGetUnsuccessfulExerciseFeedbackListByExpertAppService
	{
		Task<List<GetExerciseFeedbackListItemDto>> Run(long planId, CancellationToken cancellationToken);
	}
}
