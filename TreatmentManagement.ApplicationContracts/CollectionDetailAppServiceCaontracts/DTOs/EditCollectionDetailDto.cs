using Physioline.Framework.Application.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs
{
	public class EditCollectionDetailDto
	{
		[Required] [RequiredId] public long Id { get; set; }

		[Required] [Range(1, 1000)] public uint NumberPerDuration { get; set; }

		[Required] [Range(0, 86400)] public uint SecondsPerDuration { get; set; }
	}
}
