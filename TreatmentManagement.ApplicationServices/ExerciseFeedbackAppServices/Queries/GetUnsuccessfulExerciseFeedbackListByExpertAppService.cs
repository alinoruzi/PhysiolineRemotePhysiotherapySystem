using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseFeedbackAppServices.Queries
{
	public class GetUnsuccessfulExerciseFeedbackListByExpertAppService : IGetUnsuccessfulExerciseFeedbackListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetUnsuccessfulExerciseFeedbackListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseFeedbackListItemDto>> Run(long planId, CancellationToken cancellationToken)
			=> (await _unitOfWork.ExerciseFeedbackRepository
					.GetAllAsync(ef => ef.PlanId == planId && !ef.DoingState, cancellationToken))
				.Select(ExerciseFeedbackMapper.MapToItem).ToList();
	}
}
