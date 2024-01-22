using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;

namespace Physioline.Framework.Infrastructure.Mappings
{
	public class BaseEntityMapping : IEntityTypeConfiguration<BaseEntity>
	{

		public void Configure(EntityTypeBuilder<BaseEntity> builder)
		{
			builder.HasKey(be => be.Id);
			builder.Property(be => be.CreatedAt).IsRequired();
			builder.Property(be => be.CreatorUserId).IsRequired();
			builder.Property(be => be.IsDeleted).IsRequired();
			
			builder.HasQueryFilter(be => !be.IsDeleted);
		}
	}
}
