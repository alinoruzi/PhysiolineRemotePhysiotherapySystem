using Physioline.EM.Domain.Exceptions.CategoryExceptions;

namespace Physioline.EM.Domain.ValueObjects.CategoryValueObjects
{
	public record CategoryTitle
	{
        public string Value { get; set; }

        public CategoryTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ExerciseCategoryTitleNullOrEmptyException();
            if (title.Length > 255)
                throw new ExerciseCategoryTitleInvalidException(255);

			Value = title;
        }

        public static implicit operator CategoryTitle(string title)
            => new CategoryTitle(title);
        public static implicit operator string (CategoryTitle obj)
            => obj.Value;
    }
}
