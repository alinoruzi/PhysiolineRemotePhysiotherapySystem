namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseTitleInvalidException : Exception
    {
        public ExerciseTitleInvalidException(int maxsize) : base($"The maximum size of characters as exercise title is {maxsize}.")
		{

        }
    }
}
