namespace Physioline.EM.Domain.Exceptions.CategoryExceptions
{
	public class ExerciseCategoryDescriptionInvalidException : Exception
	{
		public ExerciseCategoryDescriptionInvalidException(int maxsize) : base($"The maximum size of characters as exercise category title is {maxsize}.")
		{

		}
	}
}
