using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class PlanMapping : IEntityTypeConfiguration<Plan>
	{

		public void Configure(EntityTypeBuilder<Plan> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("Plans", "TM");
			builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Description).IsRequired(false).HasMaxLength(2500);
			builder.Property(p => p.ExpertId).IsRequired();
			builder.Property(p => p.ClientId).IsRequired();
			
		}
	}
}
