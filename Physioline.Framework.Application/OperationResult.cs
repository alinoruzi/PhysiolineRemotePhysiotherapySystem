using System.Net;

namespace Physioline.Framework.Application
{
	public class OperationResult
	{
		public bool IsSuccess { get; private set; }
		public string Message { get; set; }

		public HttpStatusCode StatusCode { get; private set; }


		private OperationResult(string message, bool state, HttpStatusCode statusCode)
		{
			IsSuccess = state;
			Message = message;
			StatusCode = statusCode;
		}

		public static OperationResult Success(string message = "The operation was successful.")
		{
			return new OperationResult(message, true, HttpStatusCode.OK);
		}

		public static OperationResult Failed(string errorMessage, HttpStatusCode statusCode)
		{
			return new OperationResult(errorMessage, false, statusCode);
		}

		public static implicit operator bool(OperationResult operationResult)
			=> operationResult.IsSuccess;
		public static implicit operator HttpStatusCode(OperationResult operationResult)
			=> operationResult.StatusCode;
	}
}
