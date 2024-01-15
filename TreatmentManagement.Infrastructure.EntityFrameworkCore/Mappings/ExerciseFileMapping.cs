using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Enums;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExerciseFileMapping : IEntityTypeConfiguration<ExerciseFile>
	{

		public void Configure(EntityTypeBuilder<ExerciseFile> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("ExerciseFiles","TM");
			builder.Property(ef => ef.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
			builder.Property(ef => ef.Extension)
				.IsRequired()
				.HasMaxLength(255)
				.HasConversion(
					ft => ft.ToString(),
					ft => (FileExtension)Enum.Parse(typeof(FileExtension), ft)
				);
			builder.Property(ef => ef.Type)
				.IsRequired()
				.HasMaxLength(255)
				.HasConversion(
					ft => ft.ToString(),
					ft => (FileType)Enum.Parse(typeof(FileType), ft)
				);
			builder.HasOne(ef => ef.Exercise)
				.WithMany(e => e.Files)
				.HasForeignKey(ef => ef.ExerciseId)
				.IsRequired(false);
		}
	}
}
