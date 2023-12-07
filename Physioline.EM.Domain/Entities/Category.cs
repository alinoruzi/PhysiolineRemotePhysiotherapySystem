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
        
		public List<Exercise>? Exercises { get; private set; }


        public Category(string title, string description, 
	        Category? parent, List<Exercise>? exercises, 
	        long creatorUserId) : base(creatorUserId)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
			ParentId = parent.Id;
			Exercises = exercises;
		}

		public void Edit(string title, string description, 
			Category? parent, List<Exercise>? exercises)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
			ParentId = parent.Id;
			Exercises = exercises;
		}
	}
}
