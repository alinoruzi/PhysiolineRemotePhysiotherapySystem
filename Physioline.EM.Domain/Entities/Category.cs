using Physioline.EM.Domain.ValueObjects.ExerciseValueObjects;
using Physioline.EM.Domain.ValueObjects.CategoryValueObjects;
using Physioline.Shared.Domain.Entities;

namespace Physioline.EM.Domain.Entities
{
	public class Category : BaseEntity
	{
		private CategoryTitle _title;
		private CategoryDescription? _description;
		
        public string Title 
        {
	        get => _title;
			private set => _title = value;
        }
        public string? Descriptin 
        {
	        get => _description;
			private set => _description = value;
        }
        
        public long? ParentId { get; private set; }

        public Category? Parent { get; private set; }
        
        public List<Category>? Children { get; private set; }

        public List<ExerciseCategory>? ExerciseCategories { get; private set; }
		

        public Category(string title, string description,
	        Category? parent, long creatorUserId) : base(creatorUserId)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
			ParentId = parent?.Id;
			ExerciseCategories = new List<ExerciseCategory>();
		}

        public Category()
        {
            
        }

        public void Edit(string title, string description,
	        Category? parent, long creatorUserId)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
			ParentId = parent?.Id;
			ModifiedAt = DateTime.Now;
		}
	}
}
