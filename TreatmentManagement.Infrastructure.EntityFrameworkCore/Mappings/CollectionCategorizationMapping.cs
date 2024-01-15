using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class CollectionCategorizationMapping : IEntityTypeConfiguration<CollectionCategorization>
	{

		public void Configure(EntityTypeBuilder<CollectionCategorization> builder)
		{
			builder.ToTable("CollectionCategorizations","TM");
			builder.HasKey(ec=> new {ec.CollectionId, ec.CollectionCategoryId});
			builder.HasOne(cc => cc.Collection)
				.WithMany(c => c.Categorizations)
				.HasForeignKey(cc => cc.CollectionId)
				.IsRequired();
			
			builder.HasOne(cc => cc.CollectionCategory)
				.WithMany(cc => cc.Categorizations )
				.HasForeignKey(cc => cc.CollectionCategoryId)
				.IsRequired();
		}
	}
}
