using Physioline.TM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseCategoryDescription
	{
		public string Value { get; init; }

		public ExerciseCategoryDescription(string description)
		{
			if (description.Length > 2500)
				throw new ExerciseCategoryDescriptionInvalidException(2500);

			Value = description;
		}

        public static implicit operator string(ExerciseCategoryDescription obj)
			=> obj.Value;

		public static implicit operator ExerciseCategoryDescription(string description)
			=> new ExerciseCategoryDescription(description);
	}
}
