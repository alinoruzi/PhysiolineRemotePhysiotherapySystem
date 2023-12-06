using Physioline.TM.Domain.Exceptions.ExerciseGuideExceptions;

namespace Physioline.TM.Domain.ValueObjects.ExerciseGuideValueObjects
{
	public record ExercideGuideLink
	{
        public string Value { get; set; }

        public ExercideGuideLink(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ExerciseGuideLinkNullOrEmptyException();
            if (path.Contains(' '))
                throw new ExerciseGuideLinkInvalidException();

            Value = path;
        }

        public static implicit operator ExercideGuideLink(string path) 
            => new ExercideGuideLink(path);

        public static implicit operator string (ExercideGuideLink obj) 
            => obj.Value;
    }
}
