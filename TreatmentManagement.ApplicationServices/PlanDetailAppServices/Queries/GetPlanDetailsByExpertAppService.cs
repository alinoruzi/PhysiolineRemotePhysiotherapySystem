using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Queries
{
	public class GetPlanDetailsByExpertAppService : IGetPlanDetailsByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlanDetailsByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanDetailDto>> Run(long planId, long userId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.PlanDetailRepository.GetAllAsync(p
					=> p.Plan.CreatorUserId == userId && p.PlanId == planId, cancellationToken))
				.Select(PlanDetailMapper.MapToGetDto).ToList();
		}
	}
}
