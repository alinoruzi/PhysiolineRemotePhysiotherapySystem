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

		public async Task<ValueResult<GetExerciseByExpertDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return ValueResult<GetExerciseByExpertDto>.Failed(message, HttpStatusCode.NotFound);
			}

			Exercise exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);
			GetExerciseByExpertDto dto = ExerciseMapper.MapToExpertDto(exercise);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetExerciseByExpertDto>.Success(dto, message);
		}
	}
}
