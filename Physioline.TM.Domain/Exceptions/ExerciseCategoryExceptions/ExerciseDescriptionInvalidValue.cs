using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseDescriptionDescriptionInvalidValue : Exception
	{
		public ExerciseDescriptionDescriptionInvalidValue(int maxsize) : base($"The maximum size of characters as exercise category title is {maxsize}.")
		{

		}
	}
}
