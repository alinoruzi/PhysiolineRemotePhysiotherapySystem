using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseGuideExceptions
{
	public class ExerciseGuideTitleNullOrEmptyException : Exception
	{
		public ExerciseGuideTitleNullOrEmptyException() : base("Exercise guide title cannot be null or empty.")
		{

		}
	}
}
