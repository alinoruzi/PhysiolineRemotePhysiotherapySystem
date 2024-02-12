using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Enums;

namespace AccountManagement.ApplicationServices.Mappers
{
	public class UserMapper
	{
		public static User Map(AddUserDto dto, UserRole role, long userId)
			=> new User
			{
				Email = dto.Email.ToLower(),
				Mobile = dto.Mobile,
				UserRole = role,
				CreatorUserId = userId
			};

		public static Client MapToClient(RegisterClientDto dto, long userId)
			=> new Client
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Gender = (Gender)dto.Gender,
				NationalCode = dto.NationalCode,
				BirthDate = dto.BirthDate,
				CreatorUserId = userId,
			};
		
		public static Expert MapToExpert(RegisterExpertDto dto, long userId)
			=> new Expert
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Gender = (Gender)dto.Gender,
				MedicalSystemCode = dto.MedicalSystemCode,
				SpecializedTitleId = dto.SpecializedTitleId,
				ProfilePicturePath = dto.ProfilePicturePath,
				Biography = dto.Biography,
				NationalCode = dto.NationalCode,
				CreatorUserId = userId,
			};

		public static LoginResultDto MapToLoginResult(User user)
			=> new LoginResultDto()
			{
				UserId = user.Id,
				Role = user.UserRole.ToString()
			};

		public static GetUserListItemDto MapToItem(User user)
			=> new GetUserListItemDto()
			{
				Id = user.Id,
				Email = user.Email,
				FisrtName = user.Person.FirstName,
				LastName = user.Person.LastName,
				Gender = user.Person.Gender.ToString(),
				Role = user.UserRole.ToString(),
			};
	}
}
