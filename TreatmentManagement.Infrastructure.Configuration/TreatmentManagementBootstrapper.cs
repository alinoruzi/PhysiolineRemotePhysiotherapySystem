using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Commands;
using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.ExerciseCategoryAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.Queries;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Commands;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.CollectionAppServices.Commands;
using TreatmentManagement.ApplicationServices.CollectionAppServices.Queries;
using TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Commands;
using TreatmentManagement.ApplicationServices.CollectionCategoryAppServices.Queries;
using TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Commands;
using TreatmentManagement.ApplicationServices.CollectionDetailAppServices.Queries;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Commands;
using TreatmentManagement.ApplicationServices.ExerciseAppServices.Queries;
using TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Commands;
using TreatmentManagement.ApplicationServices.ExerciseCategoryAppServices.Queries;
using TreatmentManagement.ApplicationServices.PlanAppServices.Commands;
using TreatmentManagement.ApplicationServices.PlanAppServices.Queries;
using TreatmentManagement.ApplicationServices.PlanDetailAppServices.Commands;
using TreatmentManagement.ApplicationServices.PlanDetailAppServices.Queries;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Infrastructure.EntityFrameworkCore;
using TreatmentManagement.Infrastructure.EntityFrameworkCore.Repositories;

namespace TreatmentManagement.Infrastructure.Configuration
{
	public static class TreatmentManagementBootstrapper
	{
		public static void TmConfigure(this IServiceCollection services, string? connectionString)
		{
			//Application Services:

			#region CollectionAppServices

			//Commands:
			services.AddScoped<IAddCollectionByAdminAppService, AddCollectionByAdminAppService>();
			services.AddScoped<IAddCollectionByExpertAppService, AddCollectionByExpertAppService>();
			services.AddScoped<IDeleteCollectionByAdminAppService, DeleteCollectionByAdminAppService>();
			services.AddScoped<IDeleteCollectionByExpertAppService, DeleteCollectionByExpertAppService>();
			services.AddScoped<IEditCollectionByAdminAppService, EditCollectionByAdminAppService>();
			services.AddScoped<IEditCollectionByExpertAppService, EditCollectionByExpertAppService>();

			//Queries:
			services.AddScoped<IGetCollectionByAdminAppService, GetCollectionByAdminAppService>();
			services.AddScoped<IGetCollectionByExpertAppService, GetCollectionByExpertAppService>();
			services.AddScoped<IGetCollectionsPageListByAdminAppService, GetCollectionsPageListByAdminAppService>();
			services.AddScoped<IGetGlobalCollectionsPageListByExpertAppService, GetGlobalCollectionsPageListByExpertAppService>();
			services.AddScoped<IGetSpecificCollectionsPageListByExpertAppService, GetSpecificCollectionsPageListByExpertAppService>();
			services.AddScoped<ISearchCollectionByAdminAppService, SearchCollectionByAdminAppService>();
			services.AddScoped<ISearchCollectionByExpertAppService, SearchCollectionByExpertAppService>();
			services.AddScoped<IGetCollectionByClientAppService, GetCollectionByClientAppService>();

			#endregion

			#region CollectionCategoryAppServices

			//Commands:
			services.AddScoped<IAddCollectionCategoryByAdminAppService, AddCollectionCategoryByAdminAppService>();
			services.AddScoped<IDeleteCollectionCategoryByAdminAppService, DeleteCollectionCategoryByAdminAppService>();
			services.AddScoped<IEditCollectionCategoryByAdminAppService, EditCollectionCategoryByAdminAppService>();

			//Queries:
			services.AddScoped<IGetCollectionCategoriesPageListByAdminAppService, GetCollectionCategoriesPageListByAdminAppService>();
			services.AddScoped<IGetCollectionCategoryAppService, GetCollectionCategoryAppService>();
			services.AddScoped<ISearchCollectionCategoryAppService, SearchCollectionCategoryAppService>();

			#endregion

			#region CollectionDetailAppServices

			//Commands:
			services.AddScoped<IAddCollectionDetailByAdminAppService, AddCollectionDetailByAdminAppService>();
			services.AddScoped<IAddCollectionDetailByExpertAppService, AddCollectionDetailByExpertAppService>();
			services.AddScoped<IDeleteCollectionDetailByAdminAppService, DeleteCollectionDetailByAdminAppService>();
			services.AddScoped<IDeleteCollectionDetailByExpertAppService, DeleteCollectionDetailByExpertAppService>();
			services.AddScoped<IEditCollectionDetailByAdminAppService, EditCollectionDetailByAdminAppService>();
			services.AddScoped<IEditCollectionDetailByExpertAppService, EditCollectionDetailByExpertAppService>();

			//Queries:
			services.AddScoped<IGetCollectionDetailsByAdminAppService, GetCollectionDetailsByAdminAppService>();
			services.AddScoped<IGetCollectionDetailsByExpertAppService, GetCollectionDetailsByExpertAppService>();
			services.AddScoped<IGetCollectionDetailsByClientAppService, GetCollectionDetailsByClientAppService>();

			#endregion

			#region ExerciseAppServices

			//Commands:
			services.AddScoped<IAddExerciseByAdminAppService, AddExerciseByAdminAppService>();
			services.AddScoped<IAddExerciseByExpertAppService, AddExerciseByExpertAppService>();
			services.AddScoped<IDeleteExerciseByAdminAppService, DeleteExerciseByAdminAppService>();
			services.AddScoped<IDeleteExerciseByExpertAppService, DeleteExerciseByExpertAppService>();
			services.AddScoped<IEditExerciseByAdminAppService, EditExerciseByAdminAppService>();
			services.AddScoped<IEditExerciseByExpertAppService, EditExerciseByExpertAppService>();

			//Queries:
			services.AddScoped<IGetExerciseByAdminAppService, GetExerciseByAdminAppService>();
			services.AddScoped<IGetExerciseByExpertAppService, GetExerciseByExpertAppService>();
			services.AddScoped<IGetExercisesPageListByAdminAppService, GetExercisesPageListByAdminAppService>();
			services.AddScoped<IGetGlobalExercisesPageListByExpertAppService, GetGlobalExercisesPageListByExpertAppService>();
			services.AddScoped<IGetSpecificExercisesPageListByExpertAppService, GetSpecificExercisesPageListByExpertAppService>();
			services.AddScoped<ISearchExerciseByAdminAppService, SearchExerciseByAdminAppService>();
			services.AddScoped<ISearchExerciseByExpertAppService, SearchExerciseByExpertAppService>();
			services.AddScoped<IGetExerciseByClientAppService, GetExerciseByClientAppService>();

			#endregion

			#region ExerciseCategoryAppServices

			//Commands:
			services.AddScoped<IAddExerciseCategoryByAdminAppService, AddExerciseCategoryByAdminAppService>();
			services.AddScoped<IDeleteExerciseCategoryByAdminAppService, DeleteExerciseCategoryByAdminAppService>();
			services.AddScoped<IEditExerciseCategoryByAdminAppService, EditExerciseCategoryByAdminAppService>();

			//Queries:
			services.AddScoped<IGetExerciseCategoriesPageListByAdminAppService, GetExerciseCategoriesPageListByAdminAppService>();
			services.AddScoped<IGetExerciseCategoryAppService, GetExerciseCategoryAppService>();
			services.AddScoped<ISearchExerciseCategoryAppService, SearchExerciseCategoryAppService>();

			#endregion

			#region PlanAppServices

			//Commands:
			services.AddScoped<IAddPlanByExpertAppService, AddPlanByExpertAppService>();
			services.AddScoped<IDeletePlanByAdminAppService, DeletePlanByAdminAppService>();
			services.AddScoped<IDeletePlanByExpertAppService, DeletePlanByExpertAppService>();
			services.AddScoped<IEditPlanByExpertAppService, EditPlanByExpertAppService>();

			//Queries:
			services.AddScoped<IGetPlanByExpertAppService, GetPlanByExpertAppService>();
			services.AddScoped<IGetPlansListByExpertAppService, GetPlansListByExpertAppService>();
			services.AddScoped<IGetPlansPageListByAdminAppService, GetPlansPageListByAdminAppService>();
			services.AddScoped<IGetAllPlansByClientAppService, GetAllPlansByClientAppService>();
			services.AddScoped<IGetPlanByClientAppService, GetPlanByClientAppService>();

			#endregion

			#region PlanDetailAppServices

			//Commands:
			services.AddScoped<IAddPlanDetailByExpertAppService, AddPlanDetailByExpertAppService>();
			services.AddScoped<IDeletePlanDetailByExpertAppService, DeletePlanDetailByExpertAppService>();
			services.AddScoped<IEditPlanDetailByExpertAppService, EditPlanDetailByExpertAppService>();

			//Queries:
			services.AddScoped<IGetPlanDetailsByAdminAppService, GetPlanDetailsByAdminAppService>();
			services.AddScoped<IGetPlanDetailsByExpertAppService, GetPlanDetailsByExpertAppService>();
			services.AddScoped<IGetAllPlanDetailsByClientAppService, GetAllPlanDetailsByClientAppService>();

			#endregion


			//UnitOfWork:
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//DbContext:
			services.AddDbContext<TmContext>(options => options.UseSqlServer(connectionString));
		}
	}
}
