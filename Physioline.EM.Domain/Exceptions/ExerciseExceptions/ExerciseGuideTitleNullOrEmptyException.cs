namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseGuideTitleNullOrEmptyException : Exception
	{
		public ExerciseGuideTitleNullOrEmptyException() : base("Exercise guide title cannot be null or empty.")
		{

		}
	}
}
