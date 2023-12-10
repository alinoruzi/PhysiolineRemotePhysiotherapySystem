using Physioline.Framework.Domain;

namespace Physioline.Domain.Core.Entities
{
	public class Exercise : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
