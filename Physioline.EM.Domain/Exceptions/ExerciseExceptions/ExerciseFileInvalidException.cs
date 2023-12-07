using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
    public class ExerciseFileInvalidException : Exception
    {
        public ExerciseFileInvalidException() : base("The exercise image path cannot contain the space character.")
		{

        }
    }
}
