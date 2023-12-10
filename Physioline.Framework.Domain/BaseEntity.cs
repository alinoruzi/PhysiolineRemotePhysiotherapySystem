namespace Physioline.Framework.Domain
{
	public class BaseEntity
	{
		public long Id { get; set; }
		public required DateTime CreatedAt { get; init; }
		public required bool IsDeleted { get; set; }
	}
}
