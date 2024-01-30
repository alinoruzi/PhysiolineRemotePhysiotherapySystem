using Physioline.Framework.Domain;

namespace AccountManagement.Domain.Entities
{
	public class SpecializedTitle : BaseEntity
	{

		public SpecializedTitle()
		{
			Experts = new List<Expert>();
		}
		public required string Title { get; set; }
		public required string ColorCode { get; set; }
		public List<Expert> Experts { get; set; }
	}
}
