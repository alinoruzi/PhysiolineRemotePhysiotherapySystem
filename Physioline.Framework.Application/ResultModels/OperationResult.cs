using System.Net;

namespace Physioline.Framework.Application.ResultModels
{
	public class OperationResult
	{
		public bool IsSuccess { get; private set; }
		public string Message { get; set; }

		private HttpStatusCode StatusCode { get; set; }


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
		public static OperationResult Success(ResultMessage message)
		{
			return new OperationResult(message.Message, true, HttpStatusCode.OK);
		}

		public static OperationResult Failed(ResultMessage resultMessage, HttpStatusCode statusCode)
		{
			return new OperationResult(resultMessage.Message, false, statusCode);
		}
		
		public static OperationResult Failed(string resultMessage, HttpStatusCode statusCode)
		{
			return new OperationResult(resultMessage, false, statusCode);
		}

		public static implicit operator bool(OperationResult operationResult)
			=> operationResult.IsSuccess;
		public static implicit operator HttpStatusCode(OperationResult operationResult)
			=> operationResult.StatusCode;
		public static implicit operator int(OperationResult operationResult)
			=> (int)operationResult.StatusCode;
		
	}
}
