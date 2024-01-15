using Physioline.Framework.Domain;
using System.Runtime.CompilerServices;
using TreatmentManagement.Domain.Enums;

namespace TreatmentManagement.Domain.Entities
{
	public class ExerciseFile : BaseEntity
	{
		public required string Name { get; set; }
		public required FileExtension Extension { get; set; }
		public required FileType Type { get; set; }
		public long? ExerciseId { get; set; }
		public Exercise? Exercise { get; set; }

		public static implicit operator string(ExerciseFile exerciseFile)
			=> exerciseFile.Name + "." + exerciseFile.Extension;
	}
}
