using AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Queries;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Queries;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.AdminAppServices.Commands;
using AccountManagement.ApplicationServices.ClientAppServices.Commands;
using AccountManagement.ApplicationServices.ExpertAppServices.Commands;
using AccountManagement.ApplicationServices.ExpertAppServices.Queries;
using AccountManagement.ApplicationServices.SpecializedTitleAppServices.Commands;
using AccountManagement.ApplicationServices.SpecializedTitleAppServices.Queries;
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

			#region AdminappService
			//Commands:
			services.AddScoped<IRegisterAdminByAdminAppService, RegisterAdminByAdminAppService>();
			services.AddScoped<ISeedFirstAdminUserAppService, SeedFirstAdminUserAppService>();

			#endregion
			
			#region ClientAppServices
			//Commands:
			services.AddScoped<IRegisterClientAppService, RegisterClientAppService>();
			
			#endregion

			#region ExpertAppService
			//Commands:
			services.AddScoped<IRegisterExpertAppService, RegisterExpertAppService>();
			services.AddScoped<IGetExpertInfoAppService, GetExpertInfoAppService>();

			#endregion

			#region UserAppServices
			//commands:
			services.AddScoped<IAddUserAppService, AddUserAppService>();
			services.AddScoped<IConfirmUserByAdminAppService, ConfirmUserByAdminAppService>();
			services.AddScoped<IDeactivateUserByAdminAppService, DeactivateUserByAdminAppService>();
			services.AddScoped<IChangeUserPasswordByAdminAppService, ChangeUserPasswordByAdminAppService>();
			services.AddScoped<IUserChangePasswordAppService, UserChangePasswordAppService>();
			
			//Queries:
			services.AddScoped<IGetUserIdAppService, GetUserIdAppService>();
			services.AddScoped<IGetUsersPageListByAdminAppService, GetUsersPageListByAdminAppService>();
			services.AddScoped<ILoginUserAppService, LoginUserAppService>();
			services.AddScoped<IGetUserInfoAppService, GetUserInfoAppService>();
			

			#endregion

			#region SpecializedTitle
			//Commands:
			services.AddScoped<IAddSpecializedTitleByAdminAppService, AddSpecializedTitleByAdminAppService>();
			services.AddScoped<IDeleteSpecializedTitleByAdminAppService, DeleteSpecializedTitleByAdminAppService>();
			services.AddScoped<IEditSpecializedTitleByAdminAppService, EditSpecializedTitleByAdminAppService>();

			//Queries:
			services.AddScoped<IGetSpecializedTitlesPageListByAdminAppService, GetSpecializedTitlesPageListByAdminAppService>();
			services.AddScoped<IGetSpecializedTitleAppService, GetSpecializedTitleAppService>();
			services.AddScoped<ISearchSpecializedTitleAppService, SearchSpecializedTitleAppService>();
			#endregion

			//UnitOfWork:
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//DbContext:
			services.AddDbContext<AmContext>(options => options.UseSqlServer(connectionString));

		}
	}
}
