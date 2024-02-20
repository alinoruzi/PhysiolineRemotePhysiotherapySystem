using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class CollectionFeedbackMapping : IEntityTypeConfiguration<CollectionFeedback>
	{

		public void Configure(EntityTypeBuilder<CollectionFeedback> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.Property(ef => ef.DoingState).IsRequired();
			builder.Property(ef => ef.Comment).IsRequired(false).HasMaxLength(750);
			
			builder.HasOne(cf => cf.Plan)
				.WithMany(p=>p.CollectionFeedbacks)
				.HasForeignKey(cd => cd.PlanId)
				.IsRequired();builder.HasOne(cf => cf.Collection)
				.WithMany(c => c.CollectionFeedbacks)
				.HasForeignKey(cf => cf.CollectionId)
				.IsRequired();
		}
	}
}
