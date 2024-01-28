using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetPlanByClientAppService : IGetPlanByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlanByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetPlanByClientDto>> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository.IsExistAsync(p => p.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan),id);
				return ValueResult<GetPlanByClientDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsync(id, cancellationToken);

			if (plan.ClientUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return ValueResult<GetPlanByClientDto>.Failed(message, HttpStatusCode.Unauthorized);
			}

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetPlanByClientDto>.Success(PlanMapper.MapToClientDto(plan), message);
		}
	}
}
