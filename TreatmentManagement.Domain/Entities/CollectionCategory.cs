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
		public List<Collection> Collections { get; set; }

		public CollectionCategory()
		{
			Children = new List<CollectionCategory>();
			Collections = new List<Collection>();
		}
	}
}
