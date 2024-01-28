using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries
{
	public class GetExerciseCategoryAppService : IGetExerciseCategoryAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExerciseCategoryAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<ValueResult<GetExerciseCategoryDto>> Run(long id, CancellationToken cancellationToken)
		{ 
			ResultMessage message;
			if (!await _unitOfWork.ExerciseCategoryRepository
				    .IsExistAsync(ec 
					    => ec.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(ExerciseCategory), id);
				return ValueResult<GetExerciseCategoryDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var exerciseCategory = await _unitOfWork
				.ExerciseCategoryRepository.GetAsync(id, cancellationToken);

			message = ResultMessage.SuccessfullyGetData();
			
			return ValueResult<GetExerciseCategoryDto>
				.Success(ExerciseCategoryMapper.Map(exerciseCategory),message);
		}
	}
}
