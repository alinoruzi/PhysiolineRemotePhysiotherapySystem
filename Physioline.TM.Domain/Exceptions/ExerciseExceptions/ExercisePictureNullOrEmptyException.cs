using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseExceptions
{
    public class ExercisePictureNullOrEmptyException : Exception
    {
        public ExercisePictureNullOrEmptyException() : base("Exercise Picture can not be null or empty.")
        {

        }
    }
}
