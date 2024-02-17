using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DashboardController : Controller
	{
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
			=> View();
	}
}
