using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Commands
{
	public class AddPlanByExpertAppService :IAddPlanByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddPlanByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(AddPlanDto dto,
			long userId, CancellationToken cancellationToken)
		{
			var plan = PlanMapper.Map(dto, userId);
			await _unitOfWork.PlanRepository.CreateAsync(plan, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			ResultMessage message = ResultMessage.SuccessfullyAdded(nameof(Plan),plan.Id);
			return OperationResult.Success(message);
		}
	}
}
