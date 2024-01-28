using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetPlansPageListByAdminAppService : IGetPlansPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlansPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanByAdminDto>> Run(int pageNumber, int pageSize, CancellationToken cancellationToken)
			=> (await _unitOfWork.PlanRepository.GetPageAsync(pageNumber, pageSize, cancellationToken))
				.Select(PlanMapper.MapToAdminDto).ToList();
	}
}
