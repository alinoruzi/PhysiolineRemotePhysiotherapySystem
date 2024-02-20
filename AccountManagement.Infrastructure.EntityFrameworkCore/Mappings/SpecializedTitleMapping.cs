using AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class SpecializedTitleMapping : IEntityTypeConfiguration<SpecializedTitle>
	{

		public void Configure(EntityTypeBuilder<SpecializedTitle> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("SpecializedTitles", "AM");
			builder.Property(st => st.Title).IsRequired().HasMaxLength(255);
			builder.Property(st => st.ColorCode).IsRequired().HasMaxLength(9);
		}
	}
}
