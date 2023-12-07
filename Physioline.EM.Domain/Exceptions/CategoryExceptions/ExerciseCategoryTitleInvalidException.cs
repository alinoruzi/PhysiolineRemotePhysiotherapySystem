namespace Physioline.EM.Domain.Exceptions.CategoryExceptions
{
    public class ExerciseCategoryTitleInvalidException : Exception
    {
        public ExerciseCategoryTitleInvalidException(int maxsize) : base($"The maximum size of characters as exercise category title is {maxsize}.")
		{

        }
    }
}
