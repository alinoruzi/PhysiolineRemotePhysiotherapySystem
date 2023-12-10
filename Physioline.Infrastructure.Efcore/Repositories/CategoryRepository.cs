using Microsoft.EntityFrameworkCore;
using Physioline.Domain.Core.Contracts.Repositories;
using Physioline.Domain.Core.Entities;

namespace Physioline.Infrastructure.Efcore.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly PhysiolineContext _context;
		public CategoryRepository(PhysiolineContext context)
		{
			_context = context;
		}

		public async Task<Category> GetById(long id, CancellationToken cancellationToken)
			=> await _context.Categories.Where(c=>c.Id == id).FirstAsync(cancellationToken);
		public async Task<bool> IsExistById(long id, CancellationToken cancellationToken)
			=> await _context.Categories.AnyAsync(c => c.Id == id, cancellationToken);
		public async Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken)
			=> await _context.Categories.AnyAsync(c => c.Title == title.Trim(' '), cancellationToken);
		public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
			=> await _context.Categories.Where(c=>c.IsDeleted==false)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task<List<Category>> GetAllParents(CancellationToken cancellationToken)
			=> await _context.Categories.Where(c=>c.IsDeleted==false && c.ParentId == null)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task<List<Category>> GetChildrenById(long id, CancellationToken cancellationToken)
		{
			var category = await _context.Categories.Where(c => c.Id == id)
				.FirstAsync(cancellationToken);
			return category.Children;
		}
		public async Task<List<Category>> GetAllDeleted(CancellationToken cancellationToken)
			=> await _context.Categories.Where(c => c.IsDeleted)
				.Include(c => c.Children)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		public async Task Create(Category category, CancellationToken cancellationToken)
			=> await _context.Categories.AddAsync(category, cancellationToken);

		public async Task SaveChanges(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
	}
}
