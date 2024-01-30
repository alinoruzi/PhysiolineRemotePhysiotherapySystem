using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExerciseByExpertAppService : IGetExerciseByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExerciseByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ValueResult<GetExerciseByExpertDto>> Run(long id, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return ValueResult<GetExerciseByExpertDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);

			if (exercise.CreatorUserId != userId && !exercise.IsGlobal)
			{
				message = ResultMessage.DontHavePermission();
				return ValueResult<GetExerciseByExpertDto>.Failed(message, HttpStatusCode.Unauthorized);
			}

			var dto = ExerciseMapper.MapToExpertDto(exercise);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetExerciseByExpertDto>.Success(dto, message);
		}
	}
}
