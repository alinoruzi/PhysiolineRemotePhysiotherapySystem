using TreatmentManagement.ApplicationContracts.PlanAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.PlanDetailAppServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.ApplicationServices.Mappers
{
	public class PlanDetailMapper
	{
		public static PlanDetail Map(AddPlanDetailDto dto, uint priority,
			long userId)
			=> new PlanDetail
			{
				PlanId = dto.PlanId,
				CollectionId = dto.CollectionId,
				Priority = priority,
				CreatorUserId = userId,
				WeekDays = dto.WeekDays
					.Select(x => new PlanDetailWeekDay(){DayOfWeek = (DayOfWeek)x}).ToList()
			};

		public static void Map(PlanDetail entity, EditPlanDetailDto dto)
		{
			entity.WeekDays = dto.WeekDays
				.Select(x => new PlanDetailWeekDay(){DayOfWeek = (DayOfWeek)x}).ToList();
		}

		public static GetPlanDetailDto MapToGetDto(PlanDetail entity)
			=> new GetPlanDetailDto()
			{
				Id = entity.Id,
				PlanId = entity.PlanId,
				CollectionId = entity.CollectionId,
				WeekDays = entity.WeekDays
					.Select(x=>(byte)x.DayOfWeek).ToList()
			};
	}
}
