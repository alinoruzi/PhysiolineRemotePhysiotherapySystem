using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class PlanMapper
	{
		public static Plan Map(AddPlanDto dto, long userId)
			=> new Plan
			{
				Title = dto.Title,
				Description = dto.Description,
				ClientUserId = dto.ClientUserId,
				CreatorUserId = userId,
				StartDate = DateTime.Today,
				EndDate = DateTime.Today.AddDays(dto.PlanLength)
			};

		public static void Map(Plan entity, EditPlanDto dto)
		{
			entity.Title = dto.Title;
			entity.Description = dto.Description;
			entity.EndDate = entity.StartDate.AddDays(dto.PlanLength);
		}

		public static GetPlanByExpertDto MapToExpertDto(Plan entity)
			=> new GetPlanByExpertDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				ClientUserId = entity.ClientUserId,
				StartDate = entity.StartDate,
				EndDate = entity.EndDate,
				CreatedAt = entity.CreatedAt
			};

		public static GetPlanByAdminDto MapToAdminDto(Plan entity)
			=> new GetPlanByAdminDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				CreatorUserId = entity.CreatorUserId,
				ClientUserId = entity.ClientUserId,
				StartDate = entity.StartDate,
				EndDate = entity.EndDate,
				CreatedAt = entity.CreatedAt
			};
		
		public static GetPlanByClientDto MapToClientDto(Plan entity)
			=> new GetPlanByClientDto()
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				CreatorUserId = entity.CreatorUserId,
				StartDate = entity.StartDate,
				EndDate = entity.EndDate,
				IsActive = entity.EndDate >= DateTime.Today 
			};
	}
}
