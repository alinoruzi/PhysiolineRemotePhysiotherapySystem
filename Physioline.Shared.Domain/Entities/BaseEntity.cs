using Physioline.Shared.Domain.ValueObjects;

namespace Physioline.Shared.Domain.Entities
{
	public class BaseEntity
	{
        public BaseEntityId Id { get; init; }
        public BaseEntityIsDeleted IsDeleted { get; private set; }
        public BaseEntityCreatedAt CreatedAt { get; init; }

        public BaseEntity()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
