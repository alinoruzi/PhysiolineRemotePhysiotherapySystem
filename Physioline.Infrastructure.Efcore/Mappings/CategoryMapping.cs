using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Domain.Core.Entities;

namespace Physioline.Infrastructure.Efcore.Mappings
{
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{

		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories", "EM");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Title).IsRequired().HasMaxLength(255);
			builder.Property(c => c.Description).IsRequired(false).HasMaxLength(2500);
			builder.HasOne(c => c.Parent).WithMany(c => c.Children)
				.HasForeignKey(c => c.ParentId)
				.IsRequired(false);
		}
	}
}
