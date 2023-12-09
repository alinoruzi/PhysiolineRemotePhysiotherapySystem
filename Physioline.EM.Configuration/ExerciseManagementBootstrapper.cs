using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Physioline.EM.Application.Abstraction.CategoryServices.Commands;
using Physioline.EM.Application.Abstraction.CategoryServices.Queries;
using Physioline.EM.Application.CategoryServices.Commands;
using Physioline.EM.Application.CategoryServices.Queries;
using Physioline.EM.Domain.Repositories.CommandRepositories;
using Physioline.EM.Domain.Repositories.QueryRepositories;
using Physioline.EM.Infrastructure.EfCore;
using Physioline.EM.Infrastructure.EfCore.Repositories.CommandRepositories;
using Physioline.EM.Infrastructure.EfCore.Repositories.QueryRepositories;

namespace Physioline.EM.Configuration
{
	public class ExerciseManagementBootstrapper
	{
		public static void Configure(IServiceCollection services, string connectionString)
		{
			services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
			services.AddTransient<IExerciseCommandRepository, ExerciseCommandRepository>();
			services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
			services.AddTransient<IExerciseQueryRepository, ExerciseQueryRepository>();
			
			services.AddTransient<IAddCategoryByAdmin, AddCategoryByAdmin>();
			services.AddTransient<IGetCategoryListByAdmin,GetCategoryListByAdmin>();

			services.AddDbContext<EmContext>(c=>c.UseSqlServer(connectionString));
		}
	}
}
