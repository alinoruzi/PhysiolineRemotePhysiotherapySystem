using AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class ClientMapping : IEntityTypeConfiguration<Client>
	{

		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasBaseType<Person>();
			builder.ToTable("Clients", "AM");
			builder.Property(c => c.NationalCode).HasMaxLength(10).IsRequired();
			builder.Property(c => c.BirthDate).IsRequired();

			builder.HasIndex(u => u.NationalCode).IsUnique();

		}
	}
}
