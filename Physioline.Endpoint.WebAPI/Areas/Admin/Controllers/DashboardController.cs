using Microsoft.AspNetCore.Mvc;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	public class DashboardController : Controller
	{
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
			=> View();
	}
}
