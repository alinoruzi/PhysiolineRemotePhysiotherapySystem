namespace Physioline.TM.Domain.Exceptions.ExerciseGuideExceptions
{
	public class ExerciseGuideLinkInvalidException : Exception
	{
        public ExerciseGuideLinkInvalidException() : base("The exercise guide link path cannot contain the space character.")
        {
            
        }
    }
}
