using Physioline.Framework.Domain;

namespace Physioline.Domain.Core.Entities
{
	public class Category : BaseEntity
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public long? ParentId { get; set; }
		public Category? Parent { get; set; }
		public List<Category> Children { get; set; }
		public List<ExerciseCategory> ExerciseCategories { get; set; }

		public Category()
		{
			Children = new List<Category>();
			ExerciseCategories = new List<ExerciseCategory>();
		}
	}

}
