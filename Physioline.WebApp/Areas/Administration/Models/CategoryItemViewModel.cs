using System.Globalization;

namespace Physioline.WebApp.Areas.Administration.Models
{
	public class CategoryItemViewModel
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		
		public CategoryItemViewModel? Parent { get; set; }
		
		public string CreatedAt { get; set; }
		
	}
}
