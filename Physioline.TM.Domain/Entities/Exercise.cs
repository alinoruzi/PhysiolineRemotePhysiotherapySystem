using Physioline.Shared.Domain.Entities;
using Physioline.TM.Domain.ValueObjects.ExerciseValueObjects;

namespace Physioline.TM.Domain.Entities
{
	public class Exercise : BaseEntity
	{
		public ExerciseTitle Title { get; private set; }
        public ExerciseDescription? Description { get; private set; }
        public ExercisePicture Picture { get; private set; }
        public ExerciseVideo? Video { get; private set; }
        public List<ExerciseCategory> Categories { get; private set; }

        public Exercise(string title, string description, string picture, 
			string video, List<ExerciseCategory> categories)
		{
			Title = title;
			Description = description;
			Picture = picture;
			Video = video;
			Categories = categories;
		}

		public void Edit(string title, string description, string picture,
			string video, List<ExerciseCategory> categories)
		{
			Title = title;
			Description = description;
			Picture = picture;
			Video = video;
			Categories = categories;
		}
	}
}
