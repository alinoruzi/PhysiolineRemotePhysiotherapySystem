using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExerciseByAdminAppService : IGetExerciseByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetExerciseByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<ValueResult<GetExerciseByAdminDto>> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.ExerciseRepository.IsExistAsync(e => e.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return ValueResult<GetExerciseByAdminDto>.Failed(message, HttpStatusCode.NotFound);
			}

			var exercise = await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);
			var dto = ExerciseMapper.MapToAdminDto(exercise);

			message = ResultMessage.SuccessfullyGetData();
			return ValueResult<GetExerciseByAdminDto>.Success(dto, message);
		}
	}
}
