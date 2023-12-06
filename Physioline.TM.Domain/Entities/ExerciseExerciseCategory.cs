namespace Physioline.TM.Domain.Entities
{
	public class ExerciseExerciseCategory
	{
        public Exercise Exercise { get; private set; }
        public long ExerciseId { get; private set; }
        public ExerciseCategory ExerciseCategory { get; private set; }
        public long ExerciseCategoryId { get; private set; }

        public ExerciseExerciseCategory(Exercise exercise, ExerciseCategory exerciseCategory)
		{
			Exercise = exercise;
			ExerciseId = exercise.Id;
			ExerciseCategory = exerciseCategory;
			ExerciseCategoryId = exerciseCategory.Id;
		}
	}
}
