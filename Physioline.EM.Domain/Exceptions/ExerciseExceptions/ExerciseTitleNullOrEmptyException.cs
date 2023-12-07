using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
    public class ExerciseTitleNullOrEmptyException : Exception
    {
        public ExerciseTitleNullOrEmptyException() : base("Exercise title can not be null or empty.")
        {

        }
    }
}
