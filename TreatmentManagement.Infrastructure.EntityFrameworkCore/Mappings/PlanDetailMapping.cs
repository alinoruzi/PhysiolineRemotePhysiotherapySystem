using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class PlanDetailMapping : IEntityTypeConfiguration<PlanDetail>
	{

		public void Configure(EntityTypeBuilder<PlanDetail> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("PlanDetails", "TM");
			builder.HasOne(pd => pd.Plan)
				.WithMany(p => p.Details)
				.HasForeignKey(pd => pd.PlanId)
				.IsRequired();
			builder.HasOne(pd => pd.Collection)
				.WithMany(c => c.Plans)
				.HasForeignKey(pd => pd.CollectionId)
				.IsRequired();
			builder.Property(pd => pd.Priority).IsRequired();
			builder.Property(pd => pd.StartCollection).IsRequired();
			builder.Property(pd => pd.EndCollection).IsRequired();
			builder.OwnsMany(pd => pd.WeekDays, w =>
			{
				w.WithOwner().HasForeignKey(wd => wd.PlanDetailId);
				w.HasKey(wd => wd.Id);
				w.Property(wd => wd.DayOfWeek)
					.IsRequired()
					.HasMaxLength(255)
					.HasConversion(
						dow => dow.ToString(),
						dow => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dow)
					);
			});
		}
	}
}
