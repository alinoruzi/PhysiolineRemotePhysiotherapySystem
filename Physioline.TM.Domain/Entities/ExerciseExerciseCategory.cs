namespace Physioline.TM.Domain.Entities
{
	public class ExerciseExerciseCategory
	{
        public Exercise Exercise { get; private set; }
        public ExerciseCategory ExerciseCategory { get; private set; }

        public ExerciseExerciseCategory(Exercise exercise, ExerciseCategory exerciseCategory)
		{
			Exercise = exercise;
			ExerciseCategory = exerciseCategory;
		}
	}
}
