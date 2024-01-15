using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExerciseMapping : IEntityTypeConfiguration<Exercise>
	{

		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("Exercises", "TM");
			builder.Property(e => e.Title).IsRequired().HasMaxLength(255);
			builder.Property(e => e.ShortDescription).IsRequired().HasMaxLength(750);
			builder.Property(e => e.LongDescription).IsRequired(false).HasMaxLength(2500);
			builder.Property(e => e.IsGlobal).IsRequired();
			builder.OwnsMany(e => e.GuideReferences, g =>
			{
				g.WithOwner().HasForeignKey(g=>g.ExerciseId);
				g.HasKey(g => g.Id);
				g.Property(g => g.Title).IsRequired().HasMaxLength(255);
				g.Property(g => g.Url).IsRequired().HasMaxLength(2500);
			});
		}
	}
}
