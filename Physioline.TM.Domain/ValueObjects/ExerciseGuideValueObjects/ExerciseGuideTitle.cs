using Physioline.TM.Domain.Exceptions.ExerciseGuideExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseGuideValueObjects
{
	public record ExerciseGuideTitle
	{
        public string Value { get; private set; }

        public ExerciseGuideTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ExerciseGuideTitleNullOrEmptyException();
            if (title.Length > 255)
                throw new ExerciseGuideTitleInvalidException(255);

            Value = title;
        }

        public static implicit operator ExerciseGuideTitle(string title)
            => new ExerciseGuideTitle(title);

        public static implicit operator string (ExerciseGuideTitle obj)
            => obj.Value;
    }
}
