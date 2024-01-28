using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class EditExerciseCategoryByAdminAppService : IEditExerciseCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditExerciseCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(EditExerciseCategoryDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec 
					    => ec.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository
				.GetAsync(dto.Id, cancellationToken);

			if (exerciseCategory.Title != dto.Title)
			{
				if (await _unitOfWork.ExerciseCategoryRepository
					    .IsExistAsync(cc
						    => cc.Title == dto.Title, cancellationToken))
				{
					message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(ExerciseCategory), nameof(ExerciseCategory.Title));
					return OperationResult.Failed(message, HttpStatusCode.BadRequest);
				}
			}

			ExerciseCategoryMapper.MapForEdit(exerciseCategory, dto);

			_unitOfWork.ExerciseCategoryRepository.Update(exerciseCategory);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(ExerciseCategory), exerciseCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
