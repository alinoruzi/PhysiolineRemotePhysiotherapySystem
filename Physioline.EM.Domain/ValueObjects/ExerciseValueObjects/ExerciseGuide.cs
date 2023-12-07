using Physioline.EM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.EM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseGuide
	{
		public string Title { get; private set; }
		public string Link { get; private set; }

		public ExerciseGuide(string title, string link)
		{
			if (string.IsNullOrEmpty(title))
				throw new ExerciseGuideTitleNullOrEmptyException();
			if (string.IsNullOrEmpty(link))
				throw new ExerciseGuideLinkNullOrEmptyException();

			if (title.Length > 255)
				throw new ExerciseGuideTitleInvalidException(255);
			if (link.Contains(' ') || link.Length > 1500)
				throw new ExerciseGuideLinkInvalidException();

			Title = title;
			Link = link.ToLower();
		}
		
		
	}
}
