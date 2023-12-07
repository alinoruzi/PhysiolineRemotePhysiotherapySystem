using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.EM.Domain.Exceptions.ExerciseExceptions
{
    public class ExerciseFileNullOrEmptyException : Exception
    {
        public ExerciseFileNullOrEmptyException() : base("Exercise Picture can not be null or empty.")
        {

        }
    }
}
