using Physioline.TM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseTitle
	{
        public string Value { get; init; }

        public ExerciseTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ExerciseTitleNullOrEmptyException();
            if (title.Length > 255)
                throw new ExerciseTitleInvalidException(255);

			Value = title;
        }

        public static implicit operator string (ExerciseTitle obj)
            => obj.Value;
        public static implicit operator ExerciseTitle(string title)
            => new ExerciseTitle(title);
    }
}
