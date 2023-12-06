using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseExceptions
{
    public class ExercisePictureInvalidException : Exception
    {
        public ExercisePictureInvalidException() : base("The exercise image path cannot contain the space character.")
		{

        }
    }
}
