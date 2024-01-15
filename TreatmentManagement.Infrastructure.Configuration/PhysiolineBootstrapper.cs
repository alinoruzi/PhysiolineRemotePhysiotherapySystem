using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreatmentManagement.Application.Contracts.AdminServices;
using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.Commands;
using TreatmentManagement.Application.Service.AppServices;
using TreatmentManagement.Application.Service.ExerciseServices.Commands;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;
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
			services.AddTransient<IExerciseCategoryAdminService, ExerciseCategoryAdminService>();
			services.AddTransient<IExerciseCategoryRepository, ExerciseCategoryRepository>();
			
			//Repositories:
			services.AddTransient<IExerciseRepository, ExerciseRepository>();
			
			//ExerciseServices:
			services.AddTransient<IAddGlobalExercise, AddGlobalExercise>();
			
			services.AddDbContext<TMContext>(options =>options.UseSqlServer(connectionString));
		}
	}
}
