using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Commands
{
	public class EditPlanByExpertAppService : IEditPlanByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditPlanByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<OperationResult> Run(EditPlanDto dto,
			long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository
				    .IsExistAsync(p
					    => p.Id == dto.Id, cancellationToken))
				message = ResultMessage.EntityNotFound(nameof(Plan), dto.Id);

			var plan = await _unitOfWork.PlanRepository.GetAsync(dto.Id, cancellationToken);

			if (plan.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			PlanMapper.Map(plan, dto);

			_unitOfWork.PlanRepository.Update(plan);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(Plan), plan.Id);
			return OperationResult.Success(message);
		}
	}
}
