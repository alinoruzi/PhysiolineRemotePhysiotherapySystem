using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Commands
{
	public interface IAddExerciseFeedbackByClientAppService
	{
		Task<OperationResult> Run(AddExerciseFeedbackDto dto,
			long userId, CancellationToken cancellationToken);
	}
}
