using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionFeedbackAppServices.Queries
{
	public class GetUnsuccessfulCollectionFeedbackListByExpertAppService : IGetUnsuccessfulCollectionFeedbackListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetUnsuccessfulCollectionFeedbackListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionFeedbackListItemDto>> Run(long planId, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionFeedbackRepository
					.GetAllAsync(ef => ef.PlanId == planId && !ef.DoingState, cancellationToken))
				.Select(CollectionFeedbackMapper.MapToItem).ToList();
	}
}
