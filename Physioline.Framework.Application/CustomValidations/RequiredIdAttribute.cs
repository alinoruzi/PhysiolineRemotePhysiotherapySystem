using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Physioline.Framework.Application.CustomValidations
{
	public class RequiredIdAttribute : ValidationAttribute
	{
		public RequiredIdAttribute()
		{
			ErrorMessage = "The value of id is invalid.";
		}

		public override bool IsValid(object? value)
		{
			if (value == null)
				return false;
			if (!long.TryParse(value.ToString(), out long id))
				return false;
			
			return id > 0;
		}
	}
}
