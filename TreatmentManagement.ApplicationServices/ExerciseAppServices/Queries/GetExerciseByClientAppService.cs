using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExerciseByClientAppService : IGetExerciseByClientAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExerciseByClientAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<ValueResult<GetExerciseByClientDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return ValueResult<GetExerciseByClientDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);
			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository.GetAsync(exercise.CategoryId, cancellationToken);
			var dto = ExerciseMapper.MapToClientDto(exercise,exerciseCategory.Title);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetExerciseByClientDto>.Success(dto, message);
		}
	}
}
