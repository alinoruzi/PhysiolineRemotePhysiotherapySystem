using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class CollectionMapping : IEntityTypeConfiguration<Collection>
	{
		public void Configure(EntityTypeBuilder<Collection> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("Collections", "TM");
			builder.Property(c => c.Title).IsRequired().HasMaxLength(255);
			builder.Property(c => c.ShortDescription).IsRequired().HasMaxLength(750);
			builder.Property(c => c.LongDescription).IsRequired(false).HasMaxLength(2500);
			builder.Property(c => c.IsGlobal).IsRequired();

			builder.HasOne(c => c.Category)
				.WithMany(cc => cc.Collections)
				.HasForeignKey(c => c.CategoryId)
				.IsRequired();
		}
	}
}
