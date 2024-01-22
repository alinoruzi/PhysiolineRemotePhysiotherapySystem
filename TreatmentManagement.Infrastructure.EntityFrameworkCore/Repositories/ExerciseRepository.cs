using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class ExerciseRepository : BaseRepository<Exercise>,IExerciseRepository
	{
		private readonly TmContext _context;
		public ExerciseRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
