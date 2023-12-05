using Physioline.TM.Domain.Exceptions.ExerciseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExercisePicture
	{
        public string Value { get; set; }

		public ExercisePicture(string path)
		{
			if (string.IsNullOrEmpty(path)) 
				throw new ExercisePictureNullOrEmptyException();
			if (path.Contains(' '))
				throw new ExercisePictureInvalidValue();

			Value = path;
		}

		public static implicit operator ExercisePicture(string path) 
			=> new ExercisePicture(path);

		public static implicit operator string (ExercisePicture obj)
			=> obj.Value;

    }
}
