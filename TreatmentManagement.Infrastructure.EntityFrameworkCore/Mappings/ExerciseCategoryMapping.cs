using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExerciseCategoryMapping : IEntityTypeConfiguration<ExerciseCategory>
	{
		public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("ExerciseCategories", "TM");
			builder.Property(ec => ec.Title).IsRequired().HasMaxLength(255);
			builder.Property(ec => ec.Description).IsRequired(false).HasMaxLength(750);
			builder.HasOne(ec => ec.Parent)
				.WithMany(ec => ec.Children)
				.HasForeignKey(ec => ec.ParentId)
				.IsRequired(false);
		}
	}
}
