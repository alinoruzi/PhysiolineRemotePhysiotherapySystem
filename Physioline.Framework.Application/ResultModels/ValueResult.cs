using System.Net;
using System.Runtime.CompilerServices;

namespace Physioline.Framework.Application.ResultModels
{
	public class ValueResult<T> where T : class
	{
		public T Value { get; set; }
		public string Message { get; set; }
		private bool IsSuccess { get; set; }
		private HttpStatusCode StatusCode { get; set; }
		
		
		private ValueResult(string message, bool state, HttpStatusCode statusCode,T value)
		{
			Value = value;
			IsSuccess = state;
			Message = message;
			StatusCode = statusCode;
		}
		
		private ValueResult(string message, bool state, HttpStatusCode statusCode)
		{
			IsSuccess = state;
			Message = message;
			StatusCode = statusCode;
		}

		public static ValueResult<T> Success(T value, string message = "The operation was successful.")
		{
			return new ValueResult<T>(message, true, HttpStatusCode.OK,value);
		}

		public static ValueResult<T> Failed(ResultMessage resultMessage, HttpStatusCode statusCode)
		{
			return new ValueResult<T>(resultMessage.Message, false, statusCode);
		}

		public static implicit operator bool(ValueResult<T> valueResult)
			=> valueResult.IsSuccess;
		public static implicit operator HttpStatusCode(ValueResult<T> valueResult)
			=> valueResult.StatusCode;
		public static implicit operator int(ValueResult<T> valueResult)
			=> (int)valueResult.StatusCode;
		public static implicit operator ValueResult<T>(T obj)
			=> ValueResult<T>.Success(obj);
	}
}
