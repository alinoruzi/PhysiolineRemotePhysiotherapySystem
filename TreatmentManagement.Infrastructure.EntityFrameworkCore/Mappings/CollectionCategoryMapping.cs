using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class CollectionCategoryMapping : IEntityTypeConfiguration<CollectionCategory>
	{

		public void Configure(EntityTypeBuilder<CollectionCategory> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("CollectionCategories", "TM");
			builder.Property(cc => cc.Title).IsRequired().HasMaxLength(255);
			builder.Property(cc => cc.Description).IsRequired(false).HasMaxLength(750);
			
			builder.HasOne(cc => cc.Parent)
				.WithMany(cc => cc.Children)
				.HasForeignKey(cc => cc.ParentId)
				.IsRequired(false);

			builder.HasMany(cc => cc.Collections)
				.WithMany(c => c.Categories);
		}
	}
}
