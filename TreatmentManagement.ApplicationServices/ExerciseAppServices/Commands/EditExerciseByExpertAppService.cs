using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class EditExerciseByExpertAppService : IEditExerciseByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditExerciseByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditExerciseDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(dto.Id, cancellationToken);

			if (exercise.CreatorUserId != userId)
			{
				message = ResultMessage.DontHavePermission();
				return OperationResult.Failed(message, HttpStatusCode.Unauthorized);
			}

			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec => ec.Id == dto.CategoryId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.CategoryId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			ExerciseMapper.Map(exercise, dto);

			_unitOfWork.ExerciseRepository.Update(exercise);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(ExerciseCategory), exercise.Id);
			return OperationResult.Success(message);
		}
	}
}
