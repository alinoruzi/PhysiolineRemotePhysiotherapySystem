using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.EM.Domain.Entities;
using Physioline.EM.Domain.ValueObjects.ExerciseValueObjects;

namespace Physioline.EM.Infrastructure.EfCore.configurations
{
	public class ExerciseConfig : IEntityTypeConfiguration<Exercise>
	{
		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.ToTable("Exercises","EM");
			builder.Property(x => x.Id);
			builder.Property(x=>x.Title).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Description).IsRequired(false).HasMaxLength(4000);
			builder.OwnsOne(x => x.Picture);
			builder.OwnsOne(x => x.Video);
			builder.OwnsMany(e => e.Guides, g =>
			{
				g.WithOwner().HasForeignKey(g=>g.ExerciseId);
				g.Property(g => g.Id);
				g.Property(g => g.Title).IsRequired().HasMaxLength(255);
				g.Property(g => g.Link).IsRequired().HasMaxLength(1500);
			});


			
		}
	}
}
