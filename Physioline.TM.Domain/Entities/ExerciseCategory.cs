using Physioline.Shared.Domain.Entities;
using Physioline.TM.Domain.ValueObjects.ExerciseCategoryValueObjects;
using Physioline.TM.Domain.ValueObjects.ExerciseValueObjects;

namespace Physioline.TM.Domain.Entities
{
	public class ExerciseCategory : BaseEntity
	{
        public ExerciseCategoryTitle Title { get; private set; }
        public ExerciseCategoryDescription? Descriptin { get; private set; }
        public ExerciseCategory? Parent { get; set; }
		public List<Exercise>? Exercises { get; private set; }


        public ExerciseCategory(string title, string description, ExerciseCategory? parent)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
		}

		public void Edit(string title, string description, ExerciseCategory? parent)
		{
			Title = title;
			Descriptin = description;
			Parent = parent;
		}
	}
}
