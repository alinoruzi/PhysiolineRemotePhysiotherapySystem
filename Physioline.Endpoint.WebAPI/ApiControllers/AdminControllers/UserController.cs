using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreatmentManagement.ApplicationContracts.ExerciseAppServicesContracts.DTOs;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AdminControllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/admin/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IAddUserAppService _addUser;
		private readonly IGetUsersPageListByAdminAppService _geUserPages;
		private readonly IDeactivateUserByAdminAppService _deactivateUser;
		private readonly IConfirmUserByAdminAppService _confirmUser;
		private readonly IGetUserIdAppService _getUserId;

		public UserController(IAddUserAppService addUser, 
			IGetUsersPageListByAdminAppService geUserPages, 
			IDeactivateUserByAdminAppService deactivateUser, 
			IConfirmUserByAdminAppService confirmUser, 
			IGetUserIdAppService getUserId)
		{
			_addUser = addUser;
			_geUserPages = geUserPages;
			_deactivateUser = deactivateUser;
			_confirmUser = confirmUser;
			_getUserId = getUserId;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetUserListItemDto>>> UserList(CancellationToken cancellationToken,
			[FromQuery] string role = "Client",
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
		{
			var enumRole = (UserRole) Enum.Parse(typeof(UserRole), role);
			return await _geUserPages.Run(enumRole, pageNumber, pageSize, cancellationToken);
		}

		[HttpPost(Name = "expert-pre-registration")]
		public async Task<ActionResult> ExpertPreRegistration(AddUserDto dto, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _addUser.Run(dto, UserRole.Expert, userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[HttpGet(Name = "confirm-user")]
		public async Task<ActionResult> ConfirmUser(long userId, CancellationToken cancellationToken)
		{
			var result = await _confirmUser.Run(userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[HttpGet(Name = "deactivate-user")]
		public async Task<ActionResult> DeactivateUser(long userId, CancellationToken cancellationToken)
		{
			var result = await _deactivateUser.Run(userId, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[HttpPost]
		public async Task<ActionResult> GetUserId(EmailDto dto, CancellationToken cancellationToken)
		{
			var result = await _getUserId.Run(dto, cancellationToken);
			return result ? Ok(result.Value) : StatusCode(result, result.Message);
		}
		
	}
}
