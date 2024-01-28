using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class PersonMapping : IEntityTypeConfiguration<Person>
	{

		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("People", "AM");
			builder.Property(p => p.FirstName).HasMaxLength(255).IsRequired();
			builder.Property(p => p.LastName).HasMaxLength(255).IsRequired();
			builder.Property(p => p.Gender).HasConversion(
				g => g.ToString(),
				g => (Gender)Enum.Parse(typeof(Gender), g)
			).IsRequired();
			builder.HasOne(p => p.User)
				.WithOne(u => u.Person)
				.HasForeignKey<Person>(p => p.UserId);

		}
	}
}
