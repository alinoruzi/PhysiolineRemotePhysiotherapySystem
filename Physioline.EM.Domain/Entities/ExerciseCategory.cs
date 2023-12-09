namespace Physioline.EM.Domain.Entities
{
	public class ExerciseCategory
	{
        public Exercise Exercise { get; private set; }
        public long ExerciseId { get; private set; }
        public Category Category { get; private set; }
        public long CategoryId { get; private set; }

        public ExerciseCategory(Exercise exercise, Category category)
		{
			Exercise = exercise;
			ExerciseId = exercise.Id;
			Category = category;
			CategoryId = category.Id;
		}

        public ExerciseCategory()
        {
            
        }
    }
}
