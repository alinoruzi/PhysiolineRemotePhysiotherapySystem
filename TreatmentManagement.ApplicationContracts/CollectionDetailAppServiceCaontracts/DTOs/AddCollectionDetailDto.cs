using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs
{
	public class AddCollectionDetailDto
	{
		[Required] [RequiredId] public long CollectionId { get; set; }

		[Required] [RequiredId] public long ExerciseId { get; set; }

		[Required] [Range(1, 1000)] public uint NumberPerDuration { get; set; }

		[Required] [Range(0, 86400)] public uint SecondsPerDuration { get; set; }
		
	}

}
