using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
    public class ExerciseVideoInvalidException : Exception
    {
        public ExerciseVideoInvalidException() : base("The exercise video path cannot contain the space character.")
		{

        }
    }
}
