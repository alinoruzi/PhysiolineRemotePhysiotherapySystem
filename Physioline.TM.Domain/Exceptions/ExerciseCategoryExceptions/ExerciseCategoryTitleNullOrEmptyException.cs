using Physioline.TM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseExceptions
{
	public class ExerciseCategoryTitleNullOrEmptyException : Exception
	{
		public ExerciseCategoryTitleNullOrEmptyException() : base("Exercise category title can not be null or empty.")
		{

		}
	}
}
