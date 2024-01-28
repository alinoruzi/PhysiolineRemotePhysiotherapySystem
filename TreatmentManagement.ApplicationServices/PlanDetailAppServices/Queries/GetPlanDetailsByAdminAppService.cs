using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Queries
{
	public class GetPlanDetailsByAdminAppService : IGetPlanDetailsByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlanDetailsByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetPlanDetailDto>> Run(long planId, CancellationToken cancellationToken)
		{
			return (await _unitOfWork.PlanDetailRepository.GetAllAsync(p
					=> p.PlanId == planId, cancellationToken))
				.Select(PlanDetailMapper.MapToGetDto).ToList();
		}
	}
}
