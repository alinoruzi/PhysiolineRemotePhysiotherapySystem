using Physioline.EM.Domain.ValueObjects.ExerciseValueObjects;
using Physioline.Shared.Domain.Entities;

namespace Physioline.EM.Domain.Entities
{
	public class Exercise : BaseEntity
	{

		private ExerciseTitle _title;
		private ExerciseDescription? _description;


		public string Title
		{
			get => _title;
			private set => _title = value;
		}
        public string? Description 
        {
	        get => _description;
			private set => _description = value;
        }
        
        public ExerciseFile Picture { get; private set; }
        
        public ExerciseFile? Video { get; private set; }

        public List<ExerciseGuide> Guides { get; private set; }

        public List<ExerciseCategory>? ExerciseCategories { get; private set; }
        
        public Exercise(string title, string? description, string picture,
	        string video, List<ExerciseGuide> guides, long creatorUserId) : base(creatorUserId)
        {
	        Title = title;
	        Description = description;
	        Picture = picture;
	        Video = video;
	        ExerciseCategories = new List<ExerciseCategory>();
	        Guides = guides;
        }

        public Exercise()
        {
            
        }

        public void Edit(string title, string? description, string picture,
	        string video, long creatorUserId)
        {
	        Title = title;
	        Description = description;
	        Picture = picture;
	        Video = video;
	        ModifiedAt = DateTime.Now;
        }
	}
}
