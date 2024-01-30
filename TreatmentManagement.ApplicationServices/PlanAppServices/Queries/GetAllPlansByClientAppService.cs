using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetAllPlansByClientAppService : IGetAllPlansByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetAllPlansByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanByClientDto>> Run(long userId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.PlanRepository
					.GetAllAsync(p
						=> p.ClientUserId == userId, cancellationToken))
				.Select(PlanMapper.MapToClientDto).ToList();
		}
	}
}
