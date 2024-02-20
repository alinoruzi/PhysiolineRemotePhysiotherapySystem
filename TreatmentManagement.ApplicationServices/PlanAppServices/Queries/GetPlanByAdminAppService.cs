using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.PlanAppServices.Queries
{
	public class GetPlanByAdminAppService : IGetPlanByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPlanByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetPlanByAdminDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository.IsExistAsync(p => p.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan), id);
				return ValueResult<GetPlanByAdminDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsync(id, cancellationToken);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetPlanByAdminDto>.Success(PlanMapper.MapToAdminDto(plan), message);
		}
	}
}
