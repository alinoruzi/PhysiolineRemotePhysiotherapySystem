using AccountManagement.ApplicationContracts.UserAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert,Admin")]
	[Route("api/expert/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IAddUserAppService _addUser;
		private readonly IGetUserIdAppService _getUserId;
		public UserController(IAddUserAppService addUser, IGetUserIdAppService getUserId)
		{
			_addUser = addUser;
			_getUserId = getUserId;
		}

		[HttpPost(Name = "client-pre-registration")]
		public async Task<ActionResult> ClientPreRegistration(AddUserDto dto, CancellationToken cancellationToken)
		{
			var userId = long.Parse(HttpContext.User.Claims.First(c=>c.Type == "userId").Value);
			var result = await _addUser.Run(dto, UserRole.Client, userId, cancellationToken);
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
