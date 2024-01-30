using AccountManagement.Domain.Entities;
using AccountManagement.Infrastructure.EntityFrameworkCore.Mappings;
using Microsoft.EntityFrameworkCore;
using Physioline.Framework.Domain;

namespace AccountManagement.Infrastructure.EntityFrameworkCore
{
	public class AmContext : DbContext
	{
		public AmContext(DbContextOptions<AmContext> options) : base(options)
		{

		}

		public DbSet<Person> People { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Expert> Experts { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<SpecializedTitle> SpecializedTitles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
				relationship.DeleteBehavior = DeleteBehavior.NoAction;

			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new UserMapping());
			builder.ApplyConfiguration(new PersonMapping());
			builder.ApplyConfiguration(new AdminMapping());
			builder.ApplyConfiguration(new ExpertMapping());
			builder.ApplyConfiguration(new ClientMapping());
			builder.ApplyConfiguration(new SpecializedTitleMapping());

			builder.Entity<BaseEntity>().ToTable("BaseEntity", t => t.ExcludeFromMigrations());
		}
	}
}
