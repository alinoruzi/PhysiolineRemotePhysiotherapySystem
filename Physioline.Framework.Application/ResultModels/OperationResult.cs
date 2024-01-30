using System.Net;

namespace Physioline.Framework.Application.ResultModels
{
	public class OperationResult : Exception
	{


		public OperationResult(ResultMessage message) : base(message.Message)
		{
			IsSuccess = false;
			Message = message.Message;
			StatusCode = HttpStatusCode.ExpectationFailed;
		}
		private OperationResult(string message, bool state, HttpStatusCode statusCode)
		{
			IsSuccess = state;
			Message = message;
			StatusCode = statusCode;
		}
		public bool IsSuccess { get; }
		public string Message { get; set; }

		private HttpStatusCode StatusCode { get; }

		public static OperationResult Success(string message = "The operation was successful.")
			=> new OperationResult(message, true, HttpStatusCode.OK);
		public static OperationResult Success(ResultMessage message)
			=> new OperationResult(message.Message, true, HttpStatusCode.OK);

		public static OperationResult Failed(ResultMessage resultMessage, HttpStatusCode statusCode)
			=> new OperationResult(resultMessage.Message, false, statusCode);

		public static OperationResult Failed(string resultMessage, HttpStatusCode statusCode)
			=> new OperationResult(resultMessage, false, statusCode);

		public static implicit operator bool(OperationResult operationResult)
			=> operationResult.IsSuccess;
		public static implicit operator HttpStatusCode(OperationResult operationResult)
			=> operationResult.StatusCode;
		public static implicit operator int(OperationResult operationResult)
			=> (int)operationResult.StatusCode;
	}
}
