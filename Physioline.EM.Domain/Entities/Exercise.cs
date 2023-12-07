using Physioline.EM.Domain.ValueObjects.ExerciseValueObjects;
using Physioline.Shared.Domain.Entities;

namespace Physioline.EM.Domain.Entities
{
	public class Exercise : BaseEntity
	{

		private ExerciseTitle _title;
		private ExerciseDescription? _description;
		private ExerciseFile _picture;
		private ExerciseFile _video;

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
        
        public string Picture
        {
	        get => _picture;
	        private set => _picture = value;
        }
        
        public string? Video 
        {
	        get => _video;
	        private set => _video = value;
        }
        
        public List<Category> Categories { get; private set; }
        
        public Exercise(string title, string? description, string picture,
	        string video, List<Category> categories,
	        long creatorUserId) : base(creatorUserId)
        {
	        Title = title;
	        Description = description;
	        Picture = picture;
	        Video = video;
	        Categories = categories;
	        
        }
        
        public void Edit(string title, string? description, string picture,
	        string video, List<Category> categories)
        {
	        Title = title;
	        Description = description;
	        Picture = picture;
	        Video = video;
	        Categories = categories;
        }
	}
}
