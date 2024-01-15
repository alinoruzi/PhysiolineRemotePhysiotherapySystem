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

		public async Task<ExerciseCategory> GetById(long id, CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.Where(c=>c.Id == id).FirstAsync(cancellationToken);
		public async Task<bool> IsExistById(long id, CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.AnyAsync(c => c.Id == id, cancellationToken);
		public async Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.AnyAsync(c => c.Title == title.Trim(' '), cancellationToken);
		public async Task<List<ExerciseCategory>> GetAll(CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.Where(c=>c.IsDeleted==false)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task<List<ExerciseCategory>> GetAllParents(CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.Where(c=>c.IsDeleted==false && c.ParentId == null)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task<List<ExerciseCategory>> GetChildrenById(long id, CancellationToken cancellationToken)
		{
			var category = await _context.ExerciseCategories.Where(c => c.Id == id)
				.FirstAsync(cancellationToken);
			return category.Children;
		}
		public async Task<List<ExerciseCategory>> GetAllDeleted(CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.Where(c => c.IsDeleted)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task Create(ExerciseCategory exerciseCategory, CancellationToken cancellationToken)
			=> await _context.ExerciseCategories.AddAsync(exerciseCategory, cancellationToken);

		public async Task SaveChanges(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
