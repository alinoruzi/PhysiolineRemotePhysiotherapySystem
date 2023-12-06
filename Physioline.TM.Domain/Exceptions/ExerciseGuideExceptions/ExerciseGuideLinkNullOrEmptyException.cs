namespace Physioline.TM.Domain.Exceptions.ExerciseGuideExceptions
{
	public class ExerciseGuideLinkNullOrEmptyException : Exception
	{
        public ExerciseGuideLinkNullOrEmptyException() : base("Exercise guide link cannot be null or empty.")
		{

		}
	}
}
