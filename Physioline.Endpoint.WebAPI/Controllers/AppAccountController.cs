using AccountManagement.ApplicationContracts.ClientAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.ClientAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.ExpertAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Services.AuthenticationServices;
using System.Security.Claims;

namespace Physioline.Endpoint.WebAPI.Controllers
{
	public class AppAccountController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly ILoginUserAppService _login;
		private readonly IRegisterClientAppService _registerClient;
		private readonly IRegisterExpertAppService _registerExpert;
		private readonly IGetUserInfoAppService _getUserInfo;
		
		public AppAccountController(ILoginUserAppService login,
			IConfiguration configuration,
			IRegisterClientAppService registerClient,
			IRegisterExpertAppService registerExpert, 
			IGetUserInfoAppService getUserInfo)
		{
			_login = login;
			_configuration = configuration;
			_registerClient = registerClient;
			_registerExpert = registerExpert;
			_getUserInfo = getUserInfo;
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (!HttpContext.User.Identity.IsAuthenticated)
				return View();
			
			if (HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value == "Admin")
				return RedirectPermanent("/Admin/Dashboard/Index/");
			
			return RedirectToAction("Index", "Home");
		}
		
		[HttpPost]
		public async Task<IActionResult> Login(LoginInputDto dto,CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
				return View(dto);

			var result = await _login.Run(dto, cancellationToken);
			
			if (!result)
			{
				ModelState.AddModelError("LoginField",result.Message);
				return View();
			}
			var userInfo = (await _getUserInfo.Run(result.Value.UserId, cancellationToken)).Value;
			var tokenGenerator = new JwtTokenGenerator(_configuration);
			var token = tokenGenerator.Generate(result.Value.UserId, result.Value.Role, userInfo.FirstName + " " + userInfo.LastName);
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

		[HttpGet]
		public async Task<IActionResult> SignOut(CancellationToken cancellationToken)
		{
			HttpContext.Response.Cookies.Append("auth-token", "", new CookieOptions
			{
				Expires = DateTime.UtcNow.AddDays(-1),
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.Strict
			});
			return Redirect($"/Home/Index");
		}

	}
}
