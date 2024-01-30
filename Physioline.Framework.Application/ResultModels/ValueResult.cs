using System.Net;

namespace Physioline.Framework.Application.ResultModels
{
	public class ValueResult<T>
	{


		private ValueResult(string message, bool state, HttpStatusCode statusCode, T value)
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
		public T Value { get; set; }
		public string Message { get; set; }
		private bool IsSuccess { get; }
		private HttpStatusCode StatusCode { get; }

		public static ValueResult<T> Success(T value, string message = "The operation was successful.")
			=> new ValueResult<T>(message, true, HttpStatusCode.OK, value);
		public static ValueResult<T> Success(T value, ResultMessage message)
			=> new ValueResult<T>(message.Message, true, HttpStatusCode.OK, value);

		public static ValueResult<T> Failed(ResultMessage resultMessage, HttpStatusCode statusCode)
			=> new ValueResult<T>(resultMessage.Message, false, statusCode);

		public static implicit operator bool(ValueResult<T> valueResult)
			=> valueResult.IsSuccess;
		public static implicit operator HttpStatusCode(ValueResult<T> valueResult)
			=> valueResult.StatusCode;
		public static implicit operator int(ValueResult<T> valueResult)
			=> (int)valueResult.StatusCode;
		public static implicit operator ValueResult<T>(T obj)
			=> Success(obj);
	}
}
