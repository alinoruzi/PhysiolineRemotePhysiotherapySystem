namespace Physioline.Framework.Domain
{
	public class BaseEntity
	{
		protected BaseEntity()
		{
			CreatedAt = DateTime.Now;
			IsDeleted = false;
		}
		public long Id { get; set; }
		public DateTime CreatedAt { get; init; }
		public required long CreatorUserId { get; set; }
		public bool IsDeleted { get; set; }
	}
}
