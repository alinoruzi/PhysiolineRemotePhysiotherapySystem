using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.Shared.Domain.Exceptions
{
	public class BaseEntityIsDeletedInvalidValueException : Exception
	{

		public BaseEntityIsDeletedInvalidValueException(string action) : base(GenerateMessage(action))
        {
            
        }

        private static string GenerateMessage(string action)
        {
            return $"The request for {action} is not possible due to the duplication of the current state of the entity.";
        }
    }
}
