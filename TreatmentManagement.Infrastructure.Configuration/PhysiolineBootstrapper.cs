using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreatmentManagement.ApplicationContracts.AdminServices;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.AppServices;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;
using TreatmentManagement.Domain.ServiceContracts;
using TreatmentManagement.DomainServices.DomainServices;
using TreatmentManagement.Infrastructure.EntityFrameworkCore;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories.ExerciseRepositories;

namespace TreatmentManagement.Infrastructure.Configuration
{
	public class PhysiolineBootstrapper
	{
		public static void Configure(IServiceCollection services, string? connectionString)
		{
			//Domain Services:
			services.AddScoped<IExerciseService, ExerciseService>();
			services.AddScoped<IExerciseCategoryService, ExerciseCategoryService>();
			
			//Application Services:
			services.AddScoped<IExerciseCategoryAdminService, ExerciseCategoryAdminService>();
			services.AddScoped<IGetExerciseByAdminAppService,GetExerciseByAdminAppServiceAppService>();
			
			//UnitOfWork:
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			
			//Repositories:
			services.AddTransient<IExerciseRepository, ExerciseRepository>();
			services.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();

			
			//ExerciseServices:
			services.AddTransient<IAddExerciseAppService, AddExerciseAppService>();
			
			services.AddDbContext<TMContext>(options =>options.UseSqlServer(connectionString));
		}
	}
}
