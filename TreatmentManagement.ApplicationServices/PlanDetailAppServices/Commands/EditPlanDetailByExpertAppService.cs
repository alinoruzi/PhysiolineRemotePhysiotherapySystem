using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Commands
{
	public class EditPlanDetailByExpertAppService : IEditPlanDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditPlanDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditPlanDetailDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanDetailRepository
				    .IsExistAsync(p => p.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(PlanDetail), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var planDetail = await _unitOfWork.PlanDetailRepository.GetAsync(dto.Id, cancellationToken);

			if (planDetail.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			PlanDetailMapper.Map(planDetail, dto);

			_unitOfWork.PlanDetailRepository.Update(planDetail);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(PlanDetail), planDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
