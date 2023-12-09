namespace Physioline.EM.Application.Abstraction.DTOs.CategoryDTOs
{
	public class InputCategoryDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public long? ParentId { get; set; }
		public long CreatorUserId { get; set; }
	}
}
