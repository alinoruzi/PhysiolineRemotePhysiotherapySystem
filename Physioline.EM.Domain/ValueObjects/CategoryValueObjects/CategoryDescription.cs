using Physioline.EM.Domain.Exceptions.CategoryExceptions;

namespace Physioline.EM.Domain.ValueObjects.CategoryValueObjects
{
	public record CategoryDescription
	{
		public string Value { get; init; }

		public CategoryDescription(string description)
		{
			if (description.Length > 2500)
				throw new ExerciseCategoryDescriptionInvalidException(2500);

			Value = description;
		}

        public static implicit operator string(CategoryDescription obj)
			=> obj.Value;

		public static implicit operator CategoryDescription(string description)
			=> new CategoryDescription(description);
	}
}
