
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Physioline.Domain.Core.Contracts.AppServices;
using Physioline.Domain.Core.Contracts.Repositories;
using Physioline.Domain.Service.AppServices;
using Physioline.Infrastructure.Efcore;
using Physioline.Infrastructure.Efcore.Repositories;

namespace Physioline.Infrastructure.Configuration
{
	public class PhysiolineBootstrapper
	{
		public static void Configure(IServiceCollection services, string ConnectionString)
		{
			services.AddTransient<ICategoryAppService, CategoryAppService>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();

			services.AddDbContext<PhysiolineContext>(b => b.UseSqlServer(ConnectionString));
		}
	}
}
