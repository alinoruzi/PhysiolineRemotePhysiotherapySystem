using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Physioline.Framework.Domain;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class UserMapping : IEntityTypeConfiguration<User>
	{

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasBaseType<BaseEntity>();
			builder.ToTable("Users", "AM");
			builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
			builder.Property(u => u.Mobile).IsRequired().HasMaxLength(11);
			builder.Property(u => u.Password).IsRequired(false).HasMaxLength(2500);
			builder.Property(u => u.IsConfirmed).IsRequired().HasDefaultValue(false);
			builder.Property(u => u.IsConfirmed).IsRequired().HasDefaultValue(false);
			builder.Property(u => u.UserRole).HasConversion(
				ut => ut.ToString(),
				ut => (UserRole)Enum.Parse(typeof(UserRole), ut)
			).IsRequired();

			builder.HasIndex(u => u.Email).IsUnique();
			builder.HasIndex(u => u.Mobile).IsUnique();

			builder.HasOne(u => u.Person)
				.WithOne(p => p.User)
				.HasForeignKey<User>(u => u.PersonId);
		}
	}
}
