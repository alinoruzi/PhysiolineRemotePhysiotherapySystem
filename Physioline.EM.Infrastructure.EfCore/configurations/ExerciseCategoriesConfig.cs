using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.EM.Domain.Entities;

namespace Physioline.EM.Infrastructure.EfCore.configurations
{
	internal class ExerciseCategoriesConfig : IEntityTypeConfiguration<ExerciseCategory>
	{
		public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
		{
			builder.ToTable("ExerciseCategories","EM");
			builder.HasKey(ec => new {ec.ExerciseId, ec.CategoryId});
			builder.HasOne(ec => ec.Exercise)
				.WithMany(e => e.ExerciseCategories)
				.HasForeignKey(ec => ec.ExerciseId);
			builder.HasOne(ec => ec.Category)
				.WithMany(c => c.ExerciseCategories)
				.HasForeignKey(ec => ec.CategoryId);
		}
	}
}
