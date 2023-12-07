﻿using Physioline.EM.Domain.Exceptions.ExerciseExceptions;

namespace Physioline.EM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseVideo
	{
		public string Value { get; set; }

		public ExerciseVideo(string path)
		{
			if (path.Contains(' '))
				throw new ExerciseVideoInvalidException();

			Value = path;
		}

		public static implicit operator ExerciseVideo(string path)
			=> new ExerciseVideo(path);

		public static implicit operator string(ExerciseVideo obj)
			=> obj.Value;
	}
}