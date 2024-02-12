using AccountManagement.ApplicationContracts.AdminAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Services.AuthenticationServices;

namespace Physioline.Endpoint.WebAPI.ApiControllers.AccountControllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IRegisterClientAppService _registerClient;
		private readonly IRegisterExpertAppService _registerExpert;
		private readonly ILoginUserAppService _login;
		private readonly ISeedFirstAdminUserAppService _seedFirstAdmin;
		public AccountController(IRegisterClientAppService registerClient, 
			IRegisterExpertAppService registerExpert, 
			ILoginUserAppService login,
			IConfiguration configuration, 
			ISeedFirstAdminUserAppService seedFirstAdmin)
		{
			_registerClient = registerClient;
			_registerExpert = registerExpert;
			_login = login;
			_configuration = configuration;
			_seedFirstAdmin = seedFirstAdmin;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult> RegisterClient(RegisterClientDto dto, CancellationToken cancellationToken)
		{
			var result = await _registerClient.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}
		
		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult> RegisterExpert(RegisterExpertDto dto, CancellationToken cancellationToken)
		{
			var result = await _registerExpert.Run(dto, cancellationToken);
			return StatusCode(result, result.Message);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult> Login(LoginInputDto dto, CancellationToken cancellationToken)
		{
			var result = await _login.Run(dto, cancellationToken);
			
			if (!result) return StatusCode(result, result.Message);

			var tokenGenerator = new JwtTokenGenerator(_configuration);

			var token = tokenGenerator.Generate(result.Value.UserId, result.Value.Role);
			
			return Ok(token);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult> SeedAdminUser(CancellationToken cancellationToken)
		{
			var result = await _seedFirstAdmin.Run(cancellationToken);
			return StatusCode(result, result.Message);
		}
		
	}
}
