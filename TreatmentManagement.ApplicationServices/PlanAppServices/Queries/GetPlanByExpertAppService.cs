using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetPlanByExpertAppService : IGetPlanByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlanByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetPlanByExpertDto>> Run(long id,
			long userId, CancellationToken cancellationToken)
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
				return ValueResult<GetPlanByExpertDto>.Failed(message, HttpStatusCode.Unauthorized);
			}

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetPlanByExpertDto>.Success(PlanMapper.MapToExpertDto(plan), message);


		}
	}
}
