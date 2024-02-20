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
				UserId = userId
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
				UserId = userId
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
				FirstName = user.Person.FirstName,
				LastName = user.Person.LastName,
				Gender = user.Person.Gender.ToString(),
				Role = user.UserRole.ToString(),
				IsConfirmed = user.IsConfirmed
			};

		public static UserInfoDto MapToInfo(User user, Person person)
			=> new UserInfoDto()
			{
				UserId = user.Id,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Email = user.Email,
				Mobile = user.Mobile,
				Role = user.UserRole.ToString(),
				IsConfirmed = user.IsConfirmed,
				IsRegistered = user.IsRegistered,
			};

		public static ExpertInfoDto MapToExpertInfo(Expert expert)
			=> new ExpertInfoDto()
			{
				Id = expert.Id,
				UserId = expert.UserId,
				SpecializedTitleId = expert.SpecializedTitleId,
				NationalCode = expert.NationalCode,
				Biography = expert.Biography,
				MedicalSystemCode = expert.MedicalSystemCode,
				ProfilePicture = expert.ProfilePicturePath
			};
	}
}
