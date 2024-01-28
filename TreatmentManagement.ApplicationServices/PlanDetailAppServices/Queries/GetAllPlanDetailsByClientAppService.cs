using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Queries
{
	public class GetAllPlanDetailsByClientAppService : IGetAllPlanDetailsByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetAllPlanDetailsByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanDetailDto>> Run(long planId, long userId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.PlanDetailRepository
					.GetAllAsync(p => p.Plan.ClientUserId == userId && p.PlanId == planId, cancellationToken))
				.Select(PlanDetailMapper.MapToGetDto).ToList();
		}
	}
}
