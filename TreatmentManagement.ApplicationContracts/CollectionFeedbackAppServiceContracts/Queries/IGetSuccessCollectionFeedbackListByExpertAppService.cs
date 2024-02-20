using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Queries
{
	public interface IGetSuccessCollectionFeedbackListByExpertAppService
	{
		Task<List<GetCollectionFeedbackListItemDto>> Run(long planId,
			CancellationToken cancellationToken);
	}
}
