using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class ExerciseFeedbackRepository : BaseRepository<ExerciseFeedback>, IExerciseFeedbackRepository
	{
		private readonly TmContext _context;
		public ExerciseFeedbackRepository(TmContext context) : base(context)
		{
			_context = context;
		}
	}
}
