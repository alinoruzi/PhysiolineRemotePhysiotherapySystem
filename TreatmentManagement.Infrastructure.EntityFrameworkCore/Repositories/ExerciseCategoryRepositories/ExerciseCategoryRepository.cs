using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseCategoryRepositories
{
	public class ExerciseCategoryRepository : BaseRepository<ExerciseCategory>,IExerciseCategoryRepository
	{
		private readonly TMContext _context;
		public ExerciseCategoryRepository(TMContext context) : base(context)
		{
			_context = context;
		}
	}
}
