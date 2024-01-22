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
using TreatmentManagement.Domain.ServiceContracts;
using TreatmentManagement.DomainServices.DomainServices;
using TreatmentManagement.Infrastructure.EntityFrameworkCore;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories;

namespace TreatmentManagement.Infrastructure.Configuration
{
	public class PhysiolineBootstrapper
	{
		public static void Configure(IServiceCollection services, string? connectionString)
		{

			#region DomainServices
			
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
			
			//commands:
			services.AddScoped<IAddExerciseByAdminAppService, AddExerciseByAdminAppService>();
			services.AddScoped<IAddExerciseByExpertAppService, AddExerciseByExpertAppService>();
			services.AddScoped<IDeleteExerciseByAdminAppService, DeleteExerciseByAdminAppService>();
			services.AddScoped<IDeleteExerciseByExpertAppService, DeleteExerciseByExpertAppService>();
			services.AddScoped<IEditExerciseByAdminAppService,EditExerciseByAdminAppService>();
			services.AddScoped<IEditExerciseByExpertAppService, EditExerciseByExpertAppService>();
			//queries:
			services.AddScoped<IGetAllExercisesByAdminAppService, GetAllExercisesByAdminAppService>();
			services.AddScoped<IGetExerciseByAdminAppService, GetExerciseByAdminAppService>();
			services.AddScoped<IGetExerciseByExpertAppService,GetExerciseByExpertAppService>();
			services.AddScoped<IGetGlobalExercisesByExpertAppService,GetGlobalExercisesByExpertAppService>();
			services.AddScoped<IGetSpecificExercisesByExpertAppService, GetSpecificExercisesByExpertAppService>();
			services.AddScoped<ISearchExerciseAppService,SearchExerciseAppService>();
			
			#endregion
			
			
			//UnitOfWork:
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			
			//Repositories:
			services.AddTransient<IExerciseRepository, ExerciseRepository>();
			services.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();

			
			//ExerciseServices:
			services.AddTransient<IAddExerciseByAdminAppService, AddExerciseByAdminAppService>();
			
			//DbContext:
			services.AddDbContext<TmContext>(options => options.UseSqlServer(connectionString));
		}
	}
}
