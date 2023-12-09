namespace Physioline.Shared.Application.Operators
{
	public class OperationResult
	{
		public bool IsSuccess { get; private set; }
		public string Message { get; set; }


		private OperationResult(string message, bool state)
		{
			IsSuccess = state;
			Message = message;
		}

		public static OperationResult Success(string message = "The operation was successful.")
		{
			return new OperationResult(message, true);
		}

		public static OperationResult Failed(string errorMessage)
		{
			return new OperationResult(errorMessage, false);
		}
	}
}
