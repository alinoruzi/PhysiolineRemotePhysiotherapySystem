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
				Identifier = Guid.NewGuid().ToString(),
				Email = dto.Email,
				Mobile = dto.Mobile,
				UserRole = role,
				CreatorUserId = userId
			};
	}
}
