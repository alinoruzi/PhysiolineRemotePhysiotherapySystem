using Microsoft.AspNetCore.Mvc;

namespace Physioline.WebApp.Areas.Administration.Controllers
{
	public class DashboardController : Controller
	{
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			return View();
		}
	}
}
