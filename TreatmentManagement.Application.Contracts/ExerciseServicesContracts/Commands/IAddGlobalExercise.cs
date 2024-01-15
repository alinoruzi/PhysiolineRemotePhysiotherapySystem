using Physioline.Framework.Application;
using TreatmentManagement.Application.Contracts.DTOs;
using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.DTOs;

namespace TreatmentManagement.Application.Contracts.ExerciseServicesContracts.Commands
{
	public interface IAddGlobalExercise
	{
		Task<ExerciseOutputDto> Run(ExerciseInputDto inputDto, CancellationToken cancellationToken);
	}
}
