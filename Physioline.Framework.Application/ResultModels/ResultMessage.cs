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
			=> new ResultMessage($"{entityName} with id: {id} was not found.");


		public static ResultMessage RequiredPropertyIsNullOrEmpty(string entityName, string propertyName)
			=> new ResultMessage($"The value of the required property as {propertyName} in a /an {entityName} is null or empty.");
		
		public static ResultMessage AnUniquePropertyAlreadyExist (string entityName,string propertyName)
			=> new ResultMessage($"The value of the unique property as {propertyName} in the {entityName}s is already exist.");
		
		
		public static ResultMessage DontHavePermission ()
			=> new ResultMessage($"You do not have permission to perform the operation.");
		
		
		public static ResultMessage SuccessfullyAdded (string entityName,long id)
			=> new ResultMessage($"Your {entityName} has been successfully added with Id: {id} .");
		
		
		public static ResultMessage SuccessfullyEdited (string entityName,long id)
			=> new ResultMessage($"Your {entityName} has been successfully edited with Id: {id} .");
		
		
		public static ResultMessage SuccessfullyDeleted (string entityName,long id)
			=> new ResultMessage($"Your {entityName} has been successfully deleted with Id: {id} .");
		
		
		public static ResultMessage SuccessfullyGetData ()
			=> new ResultMessage($"Your operation was successful.");
		
		
		public static ResultMessage CategoryCanNotBeDelete ()
			=> new ResultMessage($"Your category cant be delete because it has any entity.");
		
		
		
		
	}
}
