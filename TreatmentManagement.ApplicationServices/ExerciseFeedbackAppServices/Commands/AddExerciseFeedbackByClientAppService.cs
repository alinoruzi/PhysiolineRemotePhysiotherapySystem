using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseFeedbackAppServices.Commands
{
	public class AddExerciseFeedbackByClientAppService : IAddExerciseFeedbackByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddExerciseFeedbackByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddExerciseFeedbackDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository.IsExistAsync(p => p.Id == dto.PlanId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan), dto.PlanId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}
			
			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == dto.ExerciseId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), dto.ExerciseId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsyncInclude(dto.PlanId, cancellationToken);

			bool exerciseExistsInPlan = plan.Details
				.Any(pd => pd.Collection.Details.Any(cd => cd.ExerciseId == dto.ExerciseId));

			if (!exerciseExistsInPlan)
			{
				message = ResultMessage.CustomMessage("تمرین مورد نظر مربوط به برنامه درمانی اعلام شده نیست.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var exerciseFeedback = ExerciseFeedbackMapper.Map(dto, userId);

			await _unitOfWork.ExerciseFeedbackRepository.CreateAsync(exerciseFeedback, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyAdded(nameof(ExerciseFeedback),exerciseFeedback.Id);
			return OperationResult.Success(message);
		}
	}
}
