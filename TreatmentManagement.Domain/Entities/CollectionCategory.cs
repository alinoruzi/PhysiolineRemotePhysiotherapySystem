using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class CollectionCategory : BaseEntity
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public long? ParentId { get; set; }
		public CollectionCategory? Parent { get; set; }
		public List<CollectionCategory> Children { get; set; }
		public List<CollectionCategorization> Categorizations { get; set; }

		public CollectionCategory()
		{
			Children = new List<CollectionCategory>();
			Categorizations = new List<CollectionCategorization>();
		}
	}
}
