using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionFeedbackAppServiceContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionFeedbackAppServices.Commands
{
	public class AddCollectionFeedbackByClientAppService : IAddCollectionFeedbackByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddCollectionFeedbackByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddCollectionFeedbackDto dto,
			long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.PlanRepository.IsExistAsync(p => p.Id == dto.PlanId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Plan), dto.PlanId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}
			
			if (!await _unitOfWork.CollectionRepository.IsExistAsync(e => e.Id == dto.CollectionId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), dto.CollectionId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var plan = await _unitOfWork.PlanRepository.GetAsyncInclude(dto.PlanId, cancellationToken);

			bool exerciseExistsInPlan = plan.Details
				.Any(pd => pd.CollectionId == dto.CollectionId);

			if (!exerciseExistsInPlan)
			{
				message = ResultMessage.CustomMessage("مجموعه تمرین مورد نظر مربوط به برنامه درمانی اعلام شده نیست.");
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var collectionFeedback = CollectionFeedbackMapper.Map(dto, userId);

			await _unitOfWork.CollectionFeedbackRepository.CreateAsync(collectionFeedback, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			message = ResultMessage.SuccessfullyAdded(nameof(ExerciseFeedback),collectionFeedback.Id);
			return OperationResult.Success(message);
		}
	}
}
