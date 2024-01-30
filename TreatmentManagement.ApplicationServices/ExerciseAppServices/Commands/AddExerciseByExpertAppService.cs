using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class AddExerciseByExpertAppService : IAddExerciseByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddExerciseByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddExerciseDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec => ec.Id == dto.CategoryId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.CategoryId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = ExerciseMapper.Map(dto, userId);
			exercise.IsGlobal = false;
			await _unitOfWork.ExerciseRepository.CreateAsync(exercise, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(exercise), exercise.Id);
			return OperationResult.Success(message);
		}
	}
}
