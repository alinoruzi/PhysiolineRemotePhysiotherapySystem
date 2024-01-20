using Physioline.Framework.Application;
using Physioline.Framework.Application.CustomValidations;
using Physioline.Framework.Application.ResultModels;
using System.Net;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries
{
	public class GetExerciseByAdminAppService : IGetExerciseByAdminAppService
	{
		private readonly IExerciseService _exerciseService;
		public GetExerciseByAdminAppService(IExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}
		
		public async Task<ValueResult<GetExerciseByAdminDto>> Run(long id, CancellationToken cancellationToken)
		{
			if (!await _exerciseService.IsExistById(id, cancellationToken))
			{
				var message = ResultMessage.EntityNotFound(nameof(Exercise), id);
				return ValueResult<GetExerciseByAdminDto>.Failed(message,HttpStatusCode.NotFound);
			}
			
			var exercise = await _exerciseService.GetById(id, cancellationToken);

			var result = ExerciseMapper.Map(exercise);

			return result;
		}
	}
}
