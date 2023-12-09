using Physioline.Shared.Domain.ValueObjects;

namespace Physioline.Shared.Domain.Entities
{
	public class BaseEntity
	{
		private BaseEntityId _id;
		private BaseEntityIsDeleted _isDeleted;
		private BaseEntityCreatedAt _createdAt;
		private BaseEntityId _creatorUserId;

		public long Id
		{
			get => _id;
			private set => _id = value;
		}
        public bool IsDeleted 
        {
	        get => _isDeleted;
			private set => _isDeleted = value;
        }
        public DateTime CreatedAt 
        {
	        get => _createdAt;
	        private set => _createdAt = value;
        }

        public DateTime ModifiedAt { get; protected set; }

        public long CreatorUserId
        {
	        get => _creatorUserId;
	        private set => _creatorUserId = value;
        }

        protected BaseEntity(long creatorUserId)
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            CreatorUserId = creatorUserId;
            ModifiedAt = DateTime.Now;
        }

        public BaseEntity()
        {
            
        }

        protected void ChangeCreatorUser(long creatorUserId)
        {
	        CreatorUserId = creatorUserId;
        }

        protected void Delete()
        {
            _isDeleted.Delete();
        }

		protected void Restore()
		{
			_isDeleted.Restore();
		}
	}
}
