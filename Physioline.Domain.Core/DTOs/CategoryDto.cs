namespace Physioline.Domain.Core.DTOs
{
	public class CategoryDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public long? ParentId { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
