using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.UserAppServices.Commands;
using AccountManagement.ApplicationServices.UserAppServices.Queries;
using AccountManagement.Domain.Repositories;
using AccountManagement.Infrastructure.EntityFrameworkCore;
using AccountManagement.Infrastructure.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Infrastructure.Configuration
{
	public static class AccountManagementBootstrapper
	{
		public static void AmConfigure(this IServiceCollection services, string? connectionString)
		{
			//ApplicationServices:
			services.AddScoped<IAddUserAppService, AddUserAppService>();
			services.AddScoped<IGetUserIdAppService, GetUserIdAppService>();

			//UnitOfWork:
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//DbContext:
			services.AddDbContext<AmContext>(options => options.UseSqlServer(connectionString));
		}
	}
}
