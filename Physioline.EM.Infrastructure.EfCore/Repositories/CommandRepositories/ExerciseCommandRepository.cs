using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.Repositories.CommandRepositories;

namespace Physioline.EM.Infrastructure.EfCore.Repositories.CommandRepositories
{
	public class ExerciseCommandRepository : IExerciseCommandRepository
	{
		private readonly EmContext _context;
		public ExerciseCommandRepository(EmContext context)
		{
			_context = context;
		}
		public async Task Create(Exercise entity, CancellationToken cancellationToken)
			=> await _context.Exercises.AddAsync(entity,cancellationToken);
		
		public async Task AddRange(IEnumerable<Exercise> entities, CancellationToken cancellationToken)
			=> await _context.Exercises.AddRangeAsync(entities,cancellationToken);
		
		public async Task Save(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
