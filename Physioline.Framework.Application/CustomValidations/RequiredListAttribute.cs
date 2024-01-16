using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Physioline.Framework.Application.CustomValidations
{
	public class RequiredListAttribute : ValidationAttribute
	{
		public RequiredListAttribute(string listName)
		{
			ErrorMessage = $"The required list: {listName}, is null or empty.";
		}
		
		
		public override bool IsValid(object? value)
		{
			var list = value as IList;
			return list is { Count: > 0 };
		}
	}
}
