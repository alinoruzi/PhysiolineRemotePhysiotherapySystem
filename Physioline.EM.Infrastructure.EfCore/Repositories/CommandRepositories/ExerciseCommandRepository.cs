using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.CommandRepositories;
using Physioline.Shared.Infrastructure.Repositories.CommandRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.CommandRepositories
{
	public class ExerciseCommandRepository : BaseCommandRepository<long, Exercise>, IExerciseCommandRepository
	{
		private readonly EmContext _context;
		public ExerciseCommandRepository(EmContext context) : base(context)
		{
			_context = context;
		}
	}
}
