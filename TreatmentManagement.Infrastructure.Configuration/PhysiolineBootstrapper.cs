using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries;
using TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands;
using TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries;
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

			#region EndregionDomainServices
			
			services.AddScoped<IExerciseService, ExerciseService>();
			services.AddScoped<IExerciseCategoryService, ExerciseCategoryService>();

			#endregion
			
			
			//Application Services:
			#region ExerciseCategoryAppServices
			services.AddScoped<IAddExerciseCategoryAppService, AddExerciseCategoryAppService>();
			services.AddScoped<IDeleteExerciseCategoryAppService, DeleteExerciseCategoryAppService>();
			services.AddScoped<IEditExerciseCategoryAppService, EditExerciseCategoryAppService>();
			services.AddScoped<IGetExerciseCategoryAppService,GetExerciseCategoryAppService>();
			services.AddScoped<IGetAllExerciseCategoriesAppService,GetAllExerciseCategoriesAppService>();
			#endregion

			#region ExerciseAppservices

			services.AddScoped<IGetExerciseByAdminAppService, GetExerciseByAdminAppService>();
			services.AddScoped<IAddExerciseAppService, AddExerciseAppService>();
			
			#endregion
			
			
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
