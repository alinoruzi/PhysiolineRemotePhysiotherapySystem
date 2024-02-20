using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Commands
{
	public interface IAddCollectionFeedbackByClientAppService
	{
		Task<OperationResult> Run(AddCollectionFeedbackDto dto,
			long userId, CancellationToken cancellationToken);
	}
}
