namespace Physioline.EM.Domain.Exceptions.CategoryExceptions
{
	public class ExerciseCategoryTitleNullOrEmptyException : Exception
	{
		public ExerciseCategoryTitleNullOrEmptyException() : base("Exercise category title can not be null or empty.")
		{

		}
	}
}
