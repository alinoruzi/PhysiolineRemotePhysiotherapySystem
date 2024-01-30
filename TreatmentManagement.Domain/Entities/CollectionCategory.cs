using Physioline.Framework.Domain;

namespace TreatmentManagement.Domain.Entities
{
	public class CollectionCategory : BaseEntity
	{

		public CollectionCategory()
		{
			Collections = new List<Collection>();
		}
		public required string Title { get; set; }
		public required string Description { get; set; }
		public List<Collection> Collections { get; set; }
	}
}
