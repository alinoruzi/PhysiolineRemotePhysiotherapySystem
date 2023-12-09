using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.EM.Domain.Entities;

namespace Physioline.EM.Infrastructure.EfCore.configurations
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{

		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories", "EM");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Descriptin).IsRequired(false).HasMaxLength(2500);
			builder.HasOne(c => c.Parent).WithMany(c => c.Children)
				.HasForeignKey(c => c.ParentId)
				.IsRequired(false);
		}
	}
}
