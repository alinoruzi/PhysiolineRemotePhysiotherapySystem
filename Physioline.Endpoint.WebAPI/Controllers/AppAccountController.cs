using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Services.AuthenticationServices;

namespace Physioline.Endpoint.WebAPI.Controllers
{
	public class AppAccountController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly ILoginUserAppService _login;
		private readonly IRegisterClientAppService _registerClient;
		private readonly IRegisterExpertAppService _registerExpert;
		
		public AppAccountController(ILoginUserAppService login,
			IConfiguration configuration,
			IRegisterClientAppService registerClient,
			IRegisterExpertAppService registerExpert)
		{
			_login = login;
			_configuration = configuration;
			_registerClient = registerClient;
			_registerExpert = registerExpert;
		}

		[HttpGet]
		public async Task<IActionResult> Login()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Login(LoginInputDto dto,CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
				return View(dto);

			var result = await _login.Run(dto, cancellationToken);
			
			if (!result)
			{
				ModelState.AddModelError("LoginField", "عملیات ورود به حساب کاربری نا موفق بود");
				return View();
			}
			
			var tokenGenerator = new JwtTokenGenerator(_configuration);
			var token = tokenGenerator.Generate(result.Value.UserId, result.Value.Role);
			HttpContext.Response.Cookies.Append("auth-token", token, new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true,
			});
				
			if(result.Value.Role == "Admin")
				return Redirect($"/Admin/Dashboard/Index/");
			
			return RedirectToAction("Index","Home");
		}


		[HttpGet]
		public async Task<IActionResult> RegisterClient(CancellationToken cancellationToken)
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> RegisterClient(RegisterClientDto dto, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
				return View(dto);

			var result = await _registerClient.Run(dto, cancellationToken);

			if (!result)
			{
				ModelState.AddModelError("RegisterField",result.Message==null ? "Exception":result.Message);
				return View();
			}
			
			return RedirectToAction("Login","AppAccount");
		}
	}
}
