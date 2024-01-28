using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands
{
	public class AddExerciseCategoryByAdminAppService : IAddExerciseCategoryByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddExerciseCategoryByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<OperationResult> Run(AddExerciseCategoryDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(cc
					    => cc.Title == dto.Title, cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(ExerciseCategory), nameof(ExerciseCategory.Title));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var exerciseCategory = ExerciseCategoryMapper.Map(dto, userId);
			await _unitOfWork.ExerciseCategoryRepository.CreateAsync(exerciseCategory, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(ExerciseCategory), exerciseCategory.Id);
			return OperationResult.Success(message);
		}
	}
}
