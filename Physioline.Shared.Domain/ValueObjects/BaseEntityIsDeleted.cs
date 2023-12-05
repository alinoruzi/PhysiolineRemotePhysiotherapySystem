using Physioline.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.Shared.Domain.ValueObjects
{
    public record BaseEntityIsDeleted
    {
        public bool Value { get; private set; }

        public BaseEntityIsDeleted(bool state)
        {
            Value = state;
        }

        public void Delete()
        {
            if (!Value)
                Value = true;
            else
                throw new BaseEntityIsDeletedInvalidValueException("delete");
        }

		public void Restore()
		{
			if (Value)
				Value = false;
			else
				throw new BaseEntityIsDeletedInvalidValueException("restore");
		}

		public static implicit operator bool (BaseEntityIsDeleted obj) 
            => obj.Value;
        public static implicit operator BaseEntityIsDeleted(bool state)
            => new(state);
    }
}
