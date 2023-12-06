using Physioline.Shared.Domain.Entities;
using Physioline.TM.Domain.ValueObjects.ExerciseGuideValueObjects;

namespace Physioline.TM.Domain.Entities
{
	public class ExerciseGuide : BaseEntity
	{
        public ExerciseGuideTitle Title { get; private set; }
        public ExercideGuideLink Link { get; private set; }
        public Exercise Exercise { get; private set; }
        public long ExerciseId { get; private set; }

        public ExerciseGuide(string title, string link, Exercise exercise)
		{
			Title = title;
			Link = link;
			Exercise = exercise;
			ExerciseId = exercise.Id;
		}

		public void Edit(string title, string link)
		{
			Title = title;
			Link = link;
		}
	}
}
