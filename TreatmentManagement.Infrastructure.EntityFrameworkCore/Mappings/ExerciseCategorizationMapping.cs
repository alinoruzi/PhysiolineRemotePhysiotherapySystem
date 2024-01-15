using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExerciseCategorizationMapping : IEntityTypeConfiguration<ExerciseCategorization>
	{
		public void Configure(EntityTypeBuilder<ExerciseCategorization> builder)
		{
			builder.ToTable("ExerciseCategorizations","TM");
			builder.HasKey(ec=> new {ec.ExerciseId, ec.ExerciseCategoryId});
			builder.HasOne(ec => ec.Exercise)
				.WithMany(e => e.Categorizations)
				.HasForeignKey(ec => ec.ExerciseId)
				.IsRequired();
			builder.HasOne(ec => ec.ExerciseCategory)
				.WithMany(c => c.Categorizations)
				.HasForeignKey(ec => ec.ExerciseCategoryId)
				.IsRequired();
		}
	}
}
