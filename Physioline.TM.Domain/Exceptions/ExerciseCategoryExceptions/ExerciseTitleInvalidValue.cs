using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.TM.Domain.Exceptions.ExerciseCategoryExceptions
{
    public class ExerciseCategoryTitleInvalidValue : Exception
    {
        public ExerciseCategoryTitleInvalidValue(int maxsize) : base($"The maximum size of characters as exercise category title is {maxsize}.")
		{

        }
    }
}
