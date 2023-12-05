using Physioline.TM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseDescription
	{
		public string Value { get; init; }

		public ExerciseDescription(string title)
		{
			if (title.Length > 2500)
				throw new ExerciseTitleInvalidValue(2500);

			Value = title;
		}

        public static implicit operator string(ExerciseDescription obj)
			=> obj.Value;

		public static implicit operator ExerciseDescription(string title)
			=> new ExerciseDescription(title);
	}
}
