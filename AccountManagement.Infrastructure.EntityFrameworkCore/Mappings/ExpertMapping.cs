using AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExpertMapping : IEntityTypeConfiguration<Expert>
	{

		public void Configure(EntityTypeBuilder<Expert> builder)
		{
			builder.HasBaseType<Person>();
			builder.ToTable("Experts", "AM");
			builder.Property(e => e.NationalCode).IsRequired().HasMaxLength(10);
			builder.Property(e => e.MedicalSystemCode).IsRequired().HasMaxLength(10);
			builder.Property(e => e.ProfilePicturePath).IsRequired().HasMaxLength(1500);
			builder.HasOne(e => e.SpecializedTitle)
				.WithMany(st => st.Experts)
				.HasForeignKey(e => e.SpecializedTitleId)
				.IsRequired();
			
			builder.HasIndex(u => u.NationalCode).IsUnique();

		}
	}
}
