using Microsoft.EntityFrameworkCore;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Infrastructure.EfCore.configurations;

namespace Physioline.EM.Infrastructure.EfCore
{
	public class EmContext : DbContext
	{
        public EmContext(DbContextOptions<EmContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ExerciseCategoriesConfig());
			modelBuilder.ApplyConfiguration(new ExerciseConfig());
			modelBuilder.ApplyConfiguration(new CategoryConfig());
		}

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
    }
}
