namespace Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs
{
	public class OutputCategoryDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		
		public OutputCategoryDto? Parent { get; set; }
		public List<OutputCategoryDto> Children { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
