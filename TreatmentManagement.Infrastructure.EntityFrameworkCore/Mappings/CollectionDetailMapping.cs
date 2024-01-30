using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class CollectionDetailMapping : IEntityTypeConfiguration<CollectionDetail>
	{

		public void Configure(EntityTypeBuilder<CollectionDetail> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("CollectionDetails", "TM");
			builder.Property(cd => cd.NumberPerDuration).IsRequired();
			builder.Property(cd => cd.SecondsOfDuration).IsRequired();
			builder.Property(cd => cd.Priority).IsRequired();

			builder.HasOne(cd => cd.Collection)
				.WithMany(c => c.Details)
				.HasForeignKey(cd => cd.CollectionId)
				.IsRequired();
			builder.HasOne(cd => cd.Exercise)
				.WithMany(e => e.Collections)
				.HasForeignKey(cd => cd.ExerciseId)
				.IsRequired();
		}
	}
}
