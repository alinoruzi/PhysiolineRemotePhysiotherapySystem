namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseGuideLinkNullOrEmptyException : Exception
	{
        public ExerciseGuideLinkNullOrEmptyException() : base("Exercise guide link cannot be null or empty.")
		{

		}
	}
}
