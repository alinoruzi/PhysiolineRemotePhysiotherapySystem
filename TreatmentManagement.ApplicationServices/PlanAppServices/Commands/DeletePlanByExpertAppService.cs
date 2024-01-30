using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Commands
{
	public class DeletePlanByExpertAppService : IDeletePlanByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeletePlanByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository
				    .IsExistAsync(p
					    => p.Id == id, cancellationToken))
				message = ResultMessage.EntityNotFound(nameof(Plan), id);

			var plan = await _unitOfWork.PlanRepository.GetAsync(id, cancellationToken);

			if (plan.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			foreach (var planDetail in plan.Details)
				planDetail.IsDeleted = true;

			plan.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(Plan), plan.Id);
			return OperationResult.Success(message);
		}
	}
}
