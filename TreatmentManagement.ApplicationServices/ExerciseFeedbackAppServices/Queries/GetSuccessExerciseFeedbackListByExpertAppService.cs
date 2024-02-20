using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseFeedbackAppServices.Queries
{
	public class GetSuccessExerciseFeedbackListByExpertAppService : IGetSuccessExerciseFeedbackListByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetSuccessExerciseFeedbackListByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetExerciseFeedbackListItemDto>> Run(long planId, CancellationToken cancellationToken)
			=> (await _unitOfWork.ExerciseFeedbackRepository
					.GetAllAsync(ef => ef.PlanId == planId && ef.DoingState, cancellationToken))
				.Select(ExerciseFeedbackMapper.MapToItem).ToList();
	}
}
