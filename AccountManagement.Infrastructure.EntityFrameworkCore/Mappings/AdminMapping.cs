using AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Mappings
{
	public class AdminMapping :IEntityTypeConfiguration<Admin>
	{

		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.HasBaseType<Person>();
			builder.ToTable("Admins", "AM");
		}
	}
}
