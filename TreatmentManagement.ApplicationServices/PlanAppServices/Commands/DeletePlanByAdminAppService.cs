using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Commands
{
	public class DeletePlanByAdminAppService : IDeletePlanByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeletePlanByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository
				    .IsExistAsync(p 
					    => p.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan),id);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsync(id, cancellationToken);
			
			
			foreach (PlanDetail planDetail in plan.Details)
			{
				planDetail.IsDeleted = true;
			}

			plan.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(Plan), plan.Id);
			return OperationResult.Success(message);
		}
	}
}