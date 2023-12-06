using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseDescriptionInvalidException : Exception
	{
		public ExerciseDescriptionInvalidException(int maxsize) : base($"The maximum size of characters as exercise title is {maxsize}.")
		{

		}
	}
}
