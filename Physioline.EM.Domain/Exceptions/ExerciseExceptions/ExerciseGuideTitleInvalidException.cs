namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseGuideTitleInvalidException :Exception
	{
        public ExerciseGuideTitleInvalidException(int maxsize) : base($"The maximum size of characters as exercise guide title is {maxsize}.")
		{

		}
	}
}
