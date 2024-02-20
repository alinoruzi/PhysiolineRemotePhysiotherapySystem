using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physioline.Endpoint.WebAPI.Areas.Admin.Models.DashboardModels;
using TreatmentManagement.Domain.Repositories;

namespace Physioline.Endpoint.WebAPI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DashboardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public DashboardController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var model = new HomeDashboardViewModel()
			{
				CountOfExercises = await _unitOfWork.ExerciseRepository.CountAllAsync(cancellationToken),
				CountOfCollections = await _unitOfWork.CollectionRepository.CountAllAsync(cancellationToken),
				CountOfPlans = await _unitOfWork.PlanRepository.CountAllAsync(cancellationToken),
			};
			
			return View(model);
		}
	}
}
