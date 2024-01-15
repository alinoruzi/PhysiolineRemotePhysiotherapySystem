using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseRepositories
{
	public class ExerciseRepository : BaseRepository<Exercise>,IExerciseRepository
	{
		private readonly TMContext _context;
		public ExerciseRepository(TMContext context) : base(context)
		{
			_context = context;
		}
	}
}
