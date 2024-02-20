using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Queries
{
	public interface IGetSuccessExerciseFeedbackListByExpertAppService
	{
		Task<List<GetExerciseFeedbackListItemDto>> Run(long planId,
			CancellationToken cancellationToken);
	}
}
