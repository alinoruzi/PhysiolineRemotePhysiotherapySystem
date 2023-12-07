using Physioline.EM.Domain.Exceptions.ExerciseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physioline.EM.Domain.ValueObjects.ExerciseValueObjects
{
	public record ExerciseFile
	{
        public string Title { get; set; }
        public string FileExtention { get; set; }

		public ExerciseFile(string title, string fileExtention)
		{
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(fileExtention)) 
				throw new ExerciseFileNullOrEmptyException();
			if (title.Contains(' ') || title.Length>255 || fileExtention.Length>10)
				throw new ExerciseFileInvalidException();

			Title = title.ToLower();
			FileExtention = fileExtention.ToLower();
		}
		
		public static implicit operator string (ExerciseFile obj)
			=> obj.Title+"."+obj.FileExtention;

		public static implicit operator ExerciseFile(string path)
		{
			var splited = path.Split('.');
			return new ExerciseFile(splited[0],splited[1]);
		}
		

	}
}
