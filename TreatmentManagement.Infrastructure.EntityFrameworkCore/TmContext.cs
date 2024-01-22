using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Infrastructure.Mappings;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore
{
	public class TmContext : DbContext
	{
		public TmContext(DbContextOptions<TmContext> options) : base(options)
		{
			
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.NoAction;
			}

			base.OnModelCreating(modelBuilder);
			
			modelBuilder.ApplyConfiguration(new BaseEntityMapping());
			
			modelBuilder.ApplyConfiguration(new ExerciseCategoryMapping());
			modelBuilder.ApplyConfiguration(new ExerciseMapping());

			modelBuilder.ApplyConfiguration(new CollectionMapping());
			modelBuilder.ApplyConfiguration(new CollectionDetailMapping());
			modelBuilder.ApplyConfiguration(new CollectionCategoryMapping());

			modelBuilder.ApplyConfiguration(new PlanMapping());
			modelBuilder.ApplyConfiguration(new PlanDetailMapping());
		}

		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
		
		public DbSet<Collection> Collections { get; set; }
		public DbSet<CollectionDetail> CollectionDetails { get; set; }
		public DbSet<CollectionCategory> CollectionCategories { get; set; }
		
		public DbSet<Plan> Plans { get; set; }
		public DbSet<PlanDetail> PlanDetails { get; set; }
	}
}
