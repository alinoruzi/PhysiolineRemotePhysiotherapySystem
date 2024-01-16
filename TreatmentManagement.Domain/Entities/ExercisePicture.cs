using Physioline.Framework.Domain;
using System.Runtime.CompilerServices;
using TreatmentManagement.Domain.Enums;

namespace TreatmentManagement.Domain.Entities
{
	public class ExercisePicture : BaseEntity
	{
		public required string Name { get; set; }
		public required FileExtension Extension { get; set; }
		public required FileType Type { get; set; }
		public required long ExerciseId { get; set; }
		public required Exercise Exercise { get; set; }

		public static implicit operator string(ExercisePicture exercisePicture)
			=> exercisePicture.Name + "." + exercisePicture.Extension;
	}
}
