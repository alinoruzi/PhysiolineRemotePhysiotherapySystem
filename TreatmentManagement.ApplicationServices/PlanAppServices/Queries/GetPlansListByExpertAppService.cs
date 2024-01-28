using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetPlansListByExpertAppService : IGetPlansListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlansListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanByExpertDto>> Run(long userId, CancellationToken cancellationToken)
			=> (await _unitOfWork.PlanRepository.GetAllAsync(p => p.CreatorUserId == userId, cancellationToken))
				.Select(PlanMapper.MapToExpertDto).ToList();
	}
}
