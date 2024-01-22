using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class ExerciseCategoryRepository : BaseRepository<ExerciseCategory>, IExerciseCategoryRepository
	{
		private readonly TmContext _context;
		public ExerciseCategoryRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
