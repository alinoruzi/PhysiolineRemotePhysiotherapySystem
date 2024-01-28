using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.ApplicationServices.PlanDetailAppServices.Commands
{
	public class AddPlanDetailByExpertAppService : IAddPlanDetailByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddPlanDetailByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddPlanDetailDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository.IsExistAsync(p => p.Id == dto.PlanId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan),dto.PlanId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsync(dto.PlanId, cancellationToken);
			if (plan.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}
			
			if (!await _unitOfWork.CollectionRepository.IsExistAsync(p => p.Id == dto.CollectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Collection),dto.CollectionId);
				return OperationResult.Failed(message,HttpStatusCode.NotFound);
			}

			var collection = await _unitOfWork.CollectionRepository.GetAsync(dto.CollectionId, cancellationToken);
			if (!collection.IsGlobal && collection.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message,HttpStatusCode.Unauthorized);
			}

			uint priority = plan.Details.Max(pd => pd.Priority);
			
			var planDetail = PlanDetailMapper.Map(dto, priority + 1, userId);

			var weekDays = dto.WeekDays.Select(wd => (DayOfWeek)wd).ToList();
			
			foreach (var dayOfWeek in weekDays)
			{			
				planDetail.WeekDays.Add(new PlanDetailWeekDay(){DayOfWeek = dayOfWeek});
			}
			
			await _unitOfWork.PlanDetailRepository.CreateAsync(planDetail, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyAdded(nameof(PlanDetail),planDetail.Id);
			return OperationResult.Success(message);
		}
	}
}
