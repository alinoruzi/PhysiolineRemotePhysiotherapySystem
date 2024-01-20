using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class CollectionCategory : BaseEntity
	{
		public required string Title { get; set; }
		public string Description { get; set; }
		public List<Collection> Collections { get; set; }

		public CollectionCategory()
		{
			Collections = new List<Collection>();
		}
	}
}
