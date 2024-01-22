using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands
{
	public class EditExerciseByAdminAppService : IEditExerciseByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditExerciseByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditExerciseDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			
			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}
			
			
			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec => ec.Id == dto.CategoryId, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.CategoryId);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			Exercise exercise = await _unitOfWork.ExerciseRepository.GetAsync(dto.Id,cancellationToken);
			
			exercise.GuideReferences.Clear();
			
			ExerciseMapper.Map(exercise, dto);
			

			_unitOfWork.ExerciseRepository.Update(exercise);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(ExerciseCategory), exercise.Id);
			return OperationResult.Success(message);
		}
	}
}
