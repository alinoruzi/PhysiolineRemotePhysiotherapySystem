using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Commands
{
	public class DeletePlanDetailByExpertAppService : IDeletePlanDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeletePlanDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanDetailRepository
				    .IsExistAsync(p => p.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(PlanDetail),id);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var planDetail = await _unitOfWork.PlanDetailRepository.GetAsync(id, cancellationToken);

			if (planDetail.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}

			planDetail.IsDeleted = true;

			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyEdited(nameof(PlanDetail), planDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
