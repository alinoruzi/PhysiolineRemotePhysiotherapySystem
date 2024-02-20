namespace Physioline.Framework.Application.ResultModels
{
	public class ResultMessage
	{
		private ResultMessage(string message)
		{
			Message = message;
		}
		public string Message { get; private set; }

		
		public static ResultMessage CustomMessage(string message)
			=> new ResultMessage(message);
		
		public static ResultMessage EntityNotFound(string entityName, long id)
			=> new ResultMessage($"رکورد مورد نظر از نوع {entityName} با شناسه {id} یافت نشد.");
		
		
		public static ResultMessage AnUniquePropertyAlreadyExist(string entityName, string propertyName)
			=> new ResultMessage($"مقدار وارد شده برای فیلد {propertyName} تکراری است.");


		public static ResultMessage DontHavePermission()
			=> new ResultMessage("شما مجوز لازم جهت اجرای این عملیات را ندارید.");


		public static ResultMessage SuccessfullyAdded(string entityName, long id)
			=> new ResultMessage($"رکورد مورد نظر از نوع {entityName} با شناسه {id} با موفقیت ایجاد شد.");


		public static ResultMessage SuccessfullyEdited(string entityName, long id)
			=> new ResultMessage($"رکورد مورد نظر از نوع {entityName} با شناسه {id} با موفقیت ویرایش شد.");


		public static ResultMessage SuccessfullyDeleted(string entityName, long id)
			=> new ResultMessage($"رکورد مورد نظر از نوع {entityName} با شناسه {id} با موفقیت حذف شد.");


		public static ResultMessage SuccessfullyGetData()
			=> new ResultMessage("عملیات با موفقیت انجام شد.");


		public static ResultMessage CategoryCanNotBeDelete()
			=> new ResultMessage("دسته بندی مورد نظر نمیتواند حذف شود. ابتدا رکوردهای وابسته آن را حذف یا ویرایش نمایید.");
		
		public static ResultMessage UserIsNotConfirmed()
			=> new ResultMessage("حساب کاربری شما غیرفعال است یا هنوز توسط مدیر سیستم تایید نشده است.");
		
		public static ResultMessage IncorrectUsernamePassword()
			=> new ResultMessage("کاربری با نام کاربری یا رمز عبور وارد شده یافت نشد.");
		
		public static ResultMessage RegistrationNotCompleted()
			=> new ResultMessage("ثبت نام شما هنوز کامل نشده است. لطفا ابتدا ثبت نام خود را کامل نمائید.");
		
		public static ResultMessage EmailMobileNotMatchForRegistration()
			=> new ResultMessage("کاربری با این ایمیل و شماره موبایل، قبلا پیش ثبت نام نشده است");
		
		public static ResultMessage UserAlreadyRegistered()
			=> new ResultMessage("شما قبلا با این ایمیل و شماره موبایل ثبت نام کرده اید.");
		
		public static ResultMessage SuccessfullyRegistered()
			=> new ResultMessage("ثبت نام شما با موفقیت تکمیل شد. چنانچه متخصص هستید منتظر تایید توسط مدیر سیستم بمانید.");
	}
}
