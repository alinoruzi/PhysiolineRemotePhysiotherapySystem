using Physioline.TM.Domain.Exceptions.ExerciseCategoryExceptions;
using Physioline.TM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseCategoryValueObjects
{
	public record ExerciseCategoryTitle
	{
        public string Value { get; set; }

        public ExerciseCategoryTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ExerciseCategoryTitleNullOrEmptyException();
            if (title.Length > 255)
                throw new ExerciseCategoryTitleInvalidValue(255);

			Value = title;
        }

        public static implicit operator ExerciseCategoryTitle(string title)
            => new ExerciseCategoryTitle(title);
        public static implicit operator string (ExerciseCategoryTitle obj)
            => obj.Value;
    }
}
