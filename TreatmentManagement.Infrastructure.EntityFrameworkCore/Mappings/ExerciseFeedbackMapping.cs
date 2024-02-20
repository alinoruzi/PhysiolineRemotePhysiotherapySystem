using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ExerciseFeedbackMapping : IEntityTypeConfiguration<ExerciseFeedback>
	{

		public void Configure(EntityTypeBuilder<ExerciseFeedback> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.Property(ef => ef.DoingState).IsRequired();
			builder.Property(ef => ef.Comment).IsRequired(false).HasMaxLength(750);
			
			builder.HasOne(ef => ef.Plan)
				.WithMany(p=>p.ExerciseFeedbacks)
				.HasForeignKey(cd => cd.PlanId)
				.IsRequired();builder.HasOne(ef => ef.Exercise)
				.WithMany(e => e.ExerciseFeedbacks)
				.HasForeignKey(ef => ef.ExerciseId)
				.IsRequired();
		}
	}
}
