using Microsoft.EntityFrameworkCore;
using Physioline.Domain.Core.Entities;
using Physioline.Infrastructure.Efcore.Mappings;

namespace Physioline.Infrastructure.Efcore
{
	public class PhysiolineContext : DbContext
	{
		public PhysiolineContext(DbContextOptions<PhysiolineContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());
		}

		public DbSet<Category> Categories { get; set; }
	}
}
