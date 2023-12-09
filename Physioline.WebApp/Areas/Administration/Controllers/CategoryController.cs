using Microsoft.AspNetCore.Mvc;
using Physioline.EM.Application.Abstraction.CategoryServices.Commands;
using Physioline.EM.Application.Abstraction.CategoryServices.Queries;
using Physioline.WebApp.Areas.Administration.Models;

namespace Physioline.WebApp.Areas.Administration.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IGetCategoryListByAdmin _getCategoryList;
		private readonly IAddCategoryByAdmin _addCategory;
		public CategoryController(IAddCategoryByAdmin addCategory, IGetCategoryListByAdmin getCategoryList)
		{
			_addCategory = addCategory;
			_getCategoryList = getCategoryList;
		}

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var categoryDtos = await _getCategoryList.Execute(cancellationToken);

			var model = categoryDtos.Select(x => new CategoryItemViewModel()
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				CreatedAt = x.CreatedAt.ToString("yy-MM-dd"),
				Parent = x.Parent == null
					? null
					: new CategoryItemViewModel()
					{
						Id = x.Parent.Id,
						Title = x.Parent.Title,
						Description = x.Parent.Description,
						CreatedAt = x.Parent.CreatedAt.ToString("yy-MM-dd")
					}
			}).ToList();
			
			return View(model);
		}
		
		[HttpGet]
		public IActionResult Add()
		{
			return Ok();
		}
		
		[HttpGet]
		public IActionResult Edit(long Id)
		{
			return Ok();
		}
		
		[HttpPost]
		public IActionResult Delete(long Id)
		{
			return Ok();
		}
	}
}
