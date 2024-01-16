namespace Physioline.Framework.Application.ResultModels
{
	public class ResultMessage
	{
		public string Message { get; private set; }
		private ResultMessage(string message)
		{
			Message = message;
		}
		
		public static ResultMessage EntityNotFound(string entityName, long id)
		{
			return new ResultMessage($"{entityName} with id: {id} was not found.");
		}
		
		public static ResultMessage RequiredPropertyIsNullOrEmpty (string entityName,string propertyName)
		{
			return new ResultMessage($"The value of the required property as {propertyName} in a /an {entityName} is null or empty.");
		}
	}
}
